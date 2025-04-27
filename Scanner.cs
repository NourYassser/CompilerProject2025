using System.Text;

namespace CompilerProject2025
{
    public enum TokenType
    {
        IDENTIFIER,
        NUMBER,
        ASSIGN,          // :=
        PLUS,            // +
        MINUS,           // -
        MULTIPLY,        // *
        DIVIDE,          // /
        EQUAL,           // =
        LESS_THAN,       // <
        LESS_EQUAL,      // <=
        GREATER_THAN,    // >
        GREATER_EQUAL,   // >=
        LEFT_PAREN,      // (
        RIGHT_PAREN,     // )
        SEMICOLON,       // ;
        BEGIN,           // BEGIN keyword
        END,             // END keyword
        IF,              // IF keyword
        THEN,            // THEN keyword
        WHILE,           // WHILE keyword
        DO,              // DO keyword
        EOF,             // End of file
        ERROR            // Error token
    }

    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }

        public Token(TokenType type, string value, int line, int column)
        {
            Type = type;
            Value = value;
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return $"[{Type}, \"{Value}\", Line: {Line}, Col: {Column}]";
        }
    }

    public class Scanner
    {
        private string _sourceCode;
        private int _position;
        private int _line;
        private int _column;
        private char _currentChar;
        private Dictionary<string, TokenType> _keywords;

        public Scanner(string sourceCode)
        {
            _sourceCode = sourceCode;
            _position = 0;
            _line = 1;
            _column = 1;
            _currentChar = _position < _sourceCode.Length ? _sourceCode[_position] : '\0';

            // Initialize keywords
            _keywords = new Dictionary<string, TokenType>
            {
                { "BEGIN", TokenType.BEGIN },
                { "END", TokenType.END },
                { "IF", TokenType.IF },
                { "THEN", TokenType.THEN },
                { "WHILE", TokenType.WHILE },
                { "DO", TokenType.DO }
            };
        }

        private void Advance()
        {
            if (_currentChar == '\n')
            {
                _line++;
                _column = 1;
            }
            else
            {
                _column++;
            }

            _position++;
            _currentChar = _position < _sourceCode.Length ? _sourceCode[_position] : '\0';
        }

        private void SkipWhitespace()
        {
            while (_currentChar != '\0' && char.IsWhiteSpace(_currentChar))
            {
                Advance();
            }
        }

        private Token ScanIdentifier()
        {
            int startLine = _line;
            int startColumn = _column;
            StringBuilder sb = new StringBuilder();

            // Collect all alphanumeric characters
            while (_currentChar != '\0' && (char.IsLetterOrDigit(_currentChar) || _currentChar == '_'))
            {
                sb.Append(_currentChar);
                Advance();
            }

            string identifierValue = sb.ToString();

            // Check if it's a keyword
            if (_keywords.ContainsKey(identifierValue))
            {
                return new Token(_keywords[identifierValue], identifierValue, startLine, startColumn);
            }
            else
            {
                return new Token(TokenType.IDENTIFIER, identifierValue, startLine, startColumn);
            }
        }

        private Token ScanNumber()
        {
            int startLine = _line;
            int startColumn = _column;
            StringBuilder sb = new StringBuilder();

            // Collect digits for integer part
            while (_currentChar != '\0' && char.IsDigit(_currentChar))
            {
                sb.Append(_currentChar);
                Advance();
            }

            // Check for decimal point
            if (_currentChar == '.')
            {
                sb.Append(_currentChar);
                Advance();

                // Collect digits for decimal part
                while (_currentChar != '\0' && char.IsDigit(_currentChar))
                {
                    sb.Append(_currentChar);
                    Advance();
                }
            }

            return new Token(TokenType.NUMBER, sb.ToString(), startLine, startColumn);
        }

        public Token GetNextToken()
        {
            // Skip whitespace
            SkipWhitespace();

            // Check for end of file
            if (_currentChar == '\0')
            {
                return new Token(TokenType.EOF, "", _line, _column);
            }

            // Store current position for error reporting
            int currentLine = _line;
            int currentColumn = _column;

            // Check for identifiers
            if (char.IsLetter(_currentChar))
            {
                return ScanIdentifier();
            }

            // Check for numbers
            if (char.IsDigit(_currentChar))
            {
                return ScanNumber();
            }

            // Check for specific tokens
            switch (_currentChar)
            {
                case ':':
                    Advance();
                    if (_currentChar == '=')
                    {
                        Advance();
                        return new Token(TokenType.ASSIGN, ":=", currentLine, currentColumn);
                    }
                    return new Token(TokenType.ERROR, ":", currentLine, currentColumn);

                case '+':
                    Advance();
                    return new Token(TokenType.PLUS, "+", currentLine, currentColumn);

                case '-':
                    Advance();
                    return new Token(TokenType.MINUS, "-", currentLine, currentColumn);

                case '*':
                    Advance();
                    return new Token(TokenType.MULTIPLY, "*", currentLine, currentColumn);

                case '/':
                    Advance();
                    return new Token(TokenType.DIVIDE, "/", currentLine, currentColumn);

                case '=':
                    Advance();
                    return new Token(TokenType.EQUAL, "=", currentLine, currentColumn);

                case '<':
                    Advance();
                    if (_currentChar == '=')
                    {
                        Advance();
                        return new Token(TokenType.LESS_EQUAL, "<=", currentLine, currentColumn);
                    }
                    return new Token(TokenType.LESS_THAN, "<", currentLine, currentColumn);

                case '>':
                    Advance();
                    if (_currentChar == '=')
                    {
                        Advance();
                        return new Token(TokenType.GREATER_EQUAL, ">=", currentLine, currentColumn);
                    }
                    return new Token(TokenType.GREATER_THAN, ">", currentLine, currentColumn);

                case '(':
                    Advance();
                    return new Token(TokenType.LEFT_PAREN, "(", currentLine, currentColumn);

                case ')':
                    Advance();
                    return new Token(TokenType.RIGHT_PAREN, ")", currentLine, currentColumn);

                case ';':
                    Advance();
                    return new Token(TokenType.SEMICOLON, ";", currentLine, currentColumn);

                default:
                    // Unknown character
                    char unknownChar = _currentChar;
                    Advance();
                    return new Token(TokenType.ERROR, unknownChar.ToString(), currentLine, currentColumn);
            }
        }

        public List<Token> ScanAllTokens()
        {
            List<Token> tokens = new List<Token>();
            Token token;

            do
            {
                token = GetNextToken();
                tokens.Add(token);
            } while (token.Type != TokenType.EOF);

            return tokens;
        }
    }
}