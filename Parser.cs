using System.Text;

namespace CompilerProject2025
{
    public class SyntaxError : Exception
    {
        public SyntaxError(string message) : base(message) { }
    }

    public class Parser
    {
        private List<Token> _tokens;
        private int _position;
        private Token _currentToken;
        private StringBuilder _parseTree;
        private int _indentLevel;

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _position = 0;
            _currentToken = _tokens[_position];
            _parseTree = new StringBuilder();
            _indentLevel = 0;
        }

        private void AddToParseTree(string node)
        {
            _parseTree.AppendLine(new string(' ', _indentLevel * 2) + node);
        }

        private void Advance()
        {
            _position++;
            if (_position < _tokens.Count)
            {
                _currentToken = _tokens[_position];
            }
        }

        private void Eat(TokenType tokenType)
        {
            if (_currentToken.Type == tokenType)
            {
                AddToParseTree($"Terminal: {_currentToken.Value}");
                Advance();
            }
            else
            {
                throw new SyntaxError($"Expected {tokenType} but got {_currentToken.Type} at line {_currentToken.Line}, column {_currentToken.Column}");
            }
        }

        // Program → statement_list
        public string Parse()
        {
            try
            {
                AddToParseTree("Program");
                _indentLevel++;
                StatementList();
                _indentLevel--;

                // Check if we've processed all tokens
                if (_currentToken.Type != TokenType.EOF)
                {
                    throw new SyntaxError($"Unexpected token {_currentToken.Type} at line {_currentToken.Line}, column {_currentToken.Column}");
                }

                return "Parsing successful.\n\nParse Tree:\n" + _parseTree.ToString();
            }
            catch (SyntaxError ex)
            {
                return "Parsing failed: " + ex.Message;
            }
        }

        // statement_list → statement statement_list | ε
        private void StatementList()
        {
            AddToParseTree("StatementList");
            _indentLevel++;

            // If the current token can start a statement
            if (_currentToken.Type == TokenType.IDENTIFIER ||
                _currentToken.Type == TokenType.BEGIN ||
                _currentToken.Type == TokenType.IF ||
                _currentToken.Type == TokenType.WHILE)
            {
                Statement();
                StatementList();
            }
            // Else: epsilon production (do nothing)

            _indentLevel--;
        }

        // statement → id ":=" expression ";" 
        // | "BEGIN" statement_list "END"
        // | "IF" condition "THEN" statement
        // | "WHILE" condition "DO" statement
        private void Statement()
        {
            AddToParseTree("Statement");
            _indentLevel++;

            switch (_currentToken.Type)
            {
                case TokenType.IDENTIFIER:
                    Eat(TokenType.IDENTIFIER);
                    Eat(TokenType.ASSIGN);
                    Expression();
                    Eat(TokenType.SEMICOLON);
                    break;

                case TokenType.BEGIN:
                    Eat(TokenType.BEGIN);
                    StatementList();
                    Eat(TokenType.END);
                    break;

                case TokenType.IF:
                    Eat(TokenType.IF);
                    Condition();
                    Eat(TokenType.THEN);
                    Statement();
                    break;

                case TokenType.WHILE:
                    Eat(TokenType.WHILE);
                    Condition();
                    Eat(TokenType.DO);
                    Statement();
                    break;

                default:
                    throw new SyntaxError($"Unexpected token {_currentToken.Type} at line {_currentToken.Line}, column {_currentToken.Column}");
            }

            _indentLevel--;
        }

        // condition → expression ("="|"<"|"<="|">"|">=") expression
        private void Condition()
        {
            AddToParseTree("Condition");
            _indentLevel++;

            Expression();

            // Relational operator
            if (_currentToken.Type == TokenType.EQUAL ||
                _currentToken.Type == TokenType.LESS_THAN ||
                _currentToken.Type == TokenType.LESS_EQUAL ||
                _currentToken.Type == TokenType.GREATER_THAN ||
                _currentToken.Type == TokenType.GREATER_EQUAL)
            {
                Eat(_currentToken.Type);
            }
            else
            {
                throw new SyntaxError($"Expected relational operator but got {_currentToken.Type} at line {_currentToken.Line}, column {_currentToken.Column}");
            }

            Expression();

            _indentLevel--;
        }

        // expression → expression "+" term | expression "–" term | term
        private void Expression()
        {
            AddToParseTree("Expression");
            _indentLevel++;

            Term();

            while (_currentToken.Type == TokenType.PLUS || _currentToken.Type == TokenType.MINUS)
            {
                Eat(_currentToken.Type);
                Term();
            }

            _indentLevel--;
        }

        // term → term "*" factor | term "/" factor | factor
        private void Term()
        {
            AddToParseTree("Term");
            _indentLevel++;

            Factor();

            while (_currentToken.Type == TokenType.MULTIPLY || _currentToken.Type == TokenType.DIVIDE)
            {
                Eat(_currentToken.Type);
                Factor();
            }

            _indentLevel--;
        }

        // factor → number | id | "(" expression ")"
        private void Factor()
        {
            AddToParseTree("Factor");
            _indentLevel++;

            switch (_currentToken.Type)
            {
                case TokenType.NUMBER:
                    Eat(TokenType.NUMBER);
                    break;

                case TokenType.IDENTIFIER:
                    Eat(TokenType.IDENTIFIER);
                    break;

                case TokenType.LEFT_PAREN:
                    Eat(TokenType.LEFT_PAREN);
                    Expression();
                    Eat(TokenType.RIGHT_PAREN);
                    break;

                default:
                    throw new SyntaxError($"Unexpected token {_currentToken.Type} at line {_currentToken.Line}, column {_currentToken.Column}");
            }

            _indentLevel--;
        }
    }
}