namespace CompilerProject2025
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtSourceCode = new System.Windows.Forms.TextBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnParse = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSourceCode
            // 
            this.txtSourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSourceCode.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceCode.Location = new System.Drawing.Point(0, 23);
            this.txtSourceCode.Multiline = true;
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSourceCode.Size = new System.Drawing.Size(400, 577);
            this.txtSourceCode.TabIndex = 0;
            this.txtSourceCode.Text = "a := x;\r\nb := y;\r\nz := 0;\r\nWHILE b > 0 DO\r\nBEGIN\r\n  IF b > 0 THEN z := z + a;" +
                "\r\n  a := 2 * a;\r\n  b := b / 2;\r\nEND\r\nIF n > 1 THEN\r\nBEGIN\r\n  f := n * f;\r\n  " +
                "n := n - 1;\r\nEND";
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScan.Location = new System.Drawing.Point(12, 615);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(120, 35);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnParse
            // 
            this.btnParse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnParse.Location = new System.Drawing.Point(138, 615);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(120, 35);
            this.btnParse.TabIndex = 2;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(0, 23);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(400, 577);
            this.txtOutput.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtSourceCode);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtOutput);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 600);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Code:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(824, 662);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.btnScan);
            this.Name = "MainForm";
            this.Text = "Compiler Project 2025";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox txtSourceCode;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                txtOutput.Clear();
                string sourceCode = txtSourceCode.Text;

                // Create a scanner and scan all tokens
                Scanner scanner = new Scanner(sourceCode);
                List<Token> tokens = scanner.ScanAllTokens();

                // Display the tokens in the output textbox
                txtOutput.AppendText("LEXICAL ANALYSIS RESULT:\r\n\r\n");
                txtOutput.AppendText("TOKEN TYPE\tVALUE\tLINE\tCOLUMN\r\n");
                txtOutput.AppendText("--------------------------------------\r\n");

                foreach (Token token in tokens)
                {
                    txtOutput.AppendText($"{token.Type}\t{token.Value}\t{token.Line}\t{token.Column}\r\n");
                }

                txtOutput.AppendText("\r\nTotal tokens: " + tokens.Count);
            }
            catch (Exception ex)
            {
                txtOutput.Text = "Error during scanning: " + ex.Message;
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            try
            {
                txtOutput.Clear();
                string sourceCode = txtSourceCode.Text;

                // First scan the code to get tokens
                Scanner scanner = new Scanner(sourceCode);
                List<Token> tokens = scanner.ScanAllTokens();

                // Display token information
                txtOutput.AppendText("LEXICAL ANALYSIS RESULT:\r\n\r\n");
                txtOutput.AppendText("TOKEN TYPE\tVALUE\tLINE\tCOLUMN\r\n");
                txtOutput.AppendText("--------------------------------------\r\n");

                foreach (Token token in tokens)
                {
                    txtOutput.AppendText($"{token.Type}\t{token.Value}\t{token.Line}\t{token.Column}\r\n");
                }

                txtOutput.AppendText("\r\nTotal tokens: " + tokens.Count + "\r\n\r\n");

                // Parse the tokens
                Parser parser = new Parser(tokens);
                string parseResult = parser.Parse();

                // Display parsing result
                txtOutput.AppendText("PARSING RESULT:\r\n\r\n");
                txtOutput.AppendText(parseResult);
            }
            catch (Exception ex)
            {
                txtOutput.Text = "Error during parsing: " + ex.Message;
            }
        }
    }
}