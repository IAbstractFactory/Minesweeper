namespace Sapper
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    cell[i, j] = new Cell();
                }
            }

            this.SuspendLayout();
            int k = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
         
                    this.cell[i, j].BackColor = System.Drawing.SystemColors.ActiveBorder;
                    this.cell[i, j].FlatAppearance.BorderSize = 0;
                    this.cell[i, j].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    this.cell[i, j].Location = new System.Drawing.Point(205 + j * 27, 74 + i * 27);
                    this.cell[i, j].Name = k.ToString();
                    this.cell[i, j].Size = new System.Drawing.Size(25, 25);
                    this.cell[i, j].TabIndex = 0;
                    this.cell[i, j].UseVisualStyleBackColor = false;
                    k++;
                }
            }

            //// Form1

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            foreach (var c in cell)
            {
                this.Controls.Add(c);
            }
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion


        private Cell[,] cell = new Cell[10, 10];
    }
}

