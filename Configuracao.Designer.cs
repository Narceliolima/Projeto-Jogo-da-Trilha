namespace Jogo_da_Trilha
{
    partial class Configuracao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracao));
            this.textoIP = new System.Windows.Forms.TextBox();
            this.botaoConecta = new System.Windows.Forms.Button();
            this.botaoCriaServer = new System.Windows.Forms.Button();
            this.textoPorta = new System.Windows.Forms.TextBox();
            this.labelIp = new System.Windows.Forms.Label();
            this.labelPorta = new System.Windows.Forms.Label();
            this.labelNick = new System.Windows.Forms.Label();
            this.textoNick = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textoIP
            // 
            this.textoIP.Location = new System.Drawing.Point(56, 16);
            this.textoIP.Name = "textoIP";
            this.textoIP.Size = new System.Drawing.Size(100, 20);
            this.textoIP.TabIndex = 0;
            this.textoIP.Text = "localhost";
            // 
            // botaoConecta
            // 
            this.botaoConecta.Location = new System.Drawing.Point(12, 120);
            this.botaoConecta.Name = "botaoConecta";
            this.botaoConecta.Size = new System.Drawing.Size(156, 23);
            this.botaoConecta.TabIndex = 2;
            this.botaoConecta.Text = "Conectar";
            this.botaoConecta.UseVisualStyleBackColor = true;
            this.botaoConecta.Click += new System.EventHandler(this.conectarCliente);
            // 
            // botaoCriaServer
            // 
            this.botaoCriaServer.Location = new System.Drawing.Point(12, 149);
            this.botaoCriaServer.Name = "botaoCriaServer";
            this.botaoCriaServer.Size = new System.Drawing.Size(156, 23);
            this.botaoCriaServer.TabIndex = 3;
            this.botaoCriaServer.Text = "Criar";
            this.botaoCriaServer.UseVisualStyleBackColor = true;
            this.botaoCriaServer.Click += new System.EventHandler(this.criarServidor);
            // 
            // textoPorta
            // 
            this.textoPorta.Location = new System.Drawing.Point(56, 48);
            this.textoPorta.Name = "textoPorta";
            this.textoPorta.Size = new System.Drawing.Size(100, 20);
            this.textoPorta.TabIndex = 1;
            this.textoPorta.Text = "8080";
            // 
            // labelIp
            // 
            this.labelIp.AutoSize = true;
            this.labelIp.Location = new System.Drawing.Point(30, 19);
            this.labelIp.Name = "labelIp";
            this.labelIp.Size = new System.Drawing.Size(20, 13);
            this.labelIp.TabIndex = 4;
            this.labelIp.Text = "IP:";
            // 
            // labelPorta
            // 
            this.labelPorta.AutoSize = true;
            this.labelPorta.Location = new System.Drawing.Point(15, 51);
            this.labelPorta.Name = "labelPorta";
            this.labelPorta.Size = new System.Drawing.Size(38, 13);
            this.labelPorta.TabIndex = 5;
            this.labelPorta.Text = "Porta: ";
            // 
            // labelNick
            // 
            this.labelNick.AutoSize = true;
            this.labelNick.Location = new System.Drawing.Point(18, 85);
            this.labelNick.Name = "labelNick";
            this.labelNick.Size = new System.Drawing.Size(35, 13);
            this.labelNick.TabIndex = 8;
            this.labelNick.Text = "Nick: ";
            // 
            // textNick
            // 
            this.textoNick.Location = new System.Drawing.Point(56, 82);
            this.textoNick.Name = "textNick";
            this.textoNick.Size = new System.Drawing.Size(100, 20);
            this.textoNick.TabIndex = 7;
            this.textoNick.Text = "Jogador";
            // 
            // Configuracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 184);
            this.Controls.Add(this.labelNick);
            this.Controls.Add(this.textoNick);
            this.Controls.Add(this.labelPorta);
            this.Controls.Add(this.labelIp);
            this.Controls.Add(this.textoPorta);
            this.Controls.Add(this.botaoCriaServer);
            this.Controls.Add(this.botaoConecta);
            this.Controls.Add(this.textoIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Configuracao";
            this.Text = "Configuracao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textoIP;
        private System.Windows.Forms.Button botaoConecta;
        private System.Windows.Forms.Button botaoCriaServer;
        private System.Windows.Forms.TextBox textoPorta;
        private System.Windows.Forms.Label labelIp;
        private System.Windows.Forms.Label labelPorta;
        private System.Windows.Forms.Label labelNick;
        private System.Windows.Forms.TextBox textoNick;
    }
}