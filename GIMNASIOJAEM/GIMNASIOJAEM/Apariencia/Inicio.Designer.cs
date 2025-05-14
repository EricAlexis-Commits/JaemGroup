namespace GIMNASIOJAEM.Apariencia
{
    partial class Inicio
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblClientes = new System.Windows.Forms.Label();
            this.lblEntrenadores = new System.Windows.Forms.Label();
            this.lblClases = new System.Windows.Forms.Label();
            this.lblMembresias = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "BIENVENIDO USUARIO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CANTIDAD TOTAL DE CLIENTES:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "CANTIDAD TOTAL DE ENTRENADORES:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "CANTIDAD TOTAL DE CLASES:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "CANTIDAD TOTAL DE MEMBRESIAS ACTIVAS:";
            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Location = new System.Drawing.Point(209, 47);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(35, 13);
            this.lblClientes.TabIndex = 5;
            this.lblClientes.Text = "label6";
            // 
            // lblEntrenadores
            // 
            this.lblEntrenadores.AutoSize = true;
            this.lblEntrenadores.Location = new System.Drawing.Point(232, 159);
            this.lblEntrenadores.Name = "lblEntrenadores";
            this.lblEntrenadores.Size = new System.Drawing.Size(35, 13);
            this.lblEntrenadores.TabIndex = 6;
            this.lblEntrenadores.Text = "label7";
            // 
            // lblClases
            // 
            this.lblClases.AutoSize = true;
            this.lblClases.Location = new System.Drawing.Point(191, 256);
            this.lblClases.Name = "lblClases";
            this.lblClases.Size = new System.Drawing.Size(35, 13);
            this.lblClases.TabIndex = 7;
            this.lblClases.Text = "label8";
            // 
            // lblMembresias
            // 
            this.lblMembresias.AutoSize = true;
            this.lblMembresias.Location = new System.Drawing.Point(611, 47);
            this.lblMembresias.Name = "lblMembresias";
            this.lblMembresias.Size = new System.Drawing.Size(35, 13);
            this.lblMembresias.TabIndex = 8;
            this.lblMembresias.Text = "label9";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMembresias);
            this.Controls.Add(this.lblClases);
            this.Controls.Add(this.lblEntrenadores);
            this.Controls.Add(this.lblClientes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblEntrenadores;
        private System.Windows.Forms.Label lblClases;
        private System.Windows.Forms.Label lblMembresias;
    }
}