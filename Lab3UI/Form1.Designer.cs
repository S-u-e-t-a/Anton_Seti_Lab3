
namespace Lab3UI
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
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.textBoxParity = new System.Windows.Forms.TextBox();
            this.textBoxVerHorParity = new System.Windows.Forms.TextBox();
            this.textBoxCRC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(13, 13);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(115, 23);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Text = "Открыть файл";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // textBoxParity
            // 
            this.textBoxParity.Location = new System.Drawing.Point(13, 69);
            this.textBoxParity.Multiline = true;
            this.textBoxParity.Name = "textBoxParity";
            this.textBoxParity.ReadOnly = true;
            this.textBoxParity.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxParity.Size = new System.Drawing.Size(666, 56);
            this.textBoxParity.TabIndex = 1;
            // 
            // textBoxVerHorParity
            // 
            this.textBoxVerHorParity.Location = new System.Drawing.Point(13, 167);
            this.textBoxVerHorParity.Multiline = true;
            this.textBoxVerHorParity.Name = "textBoxVerHorParity";
            this.textBoxVerHorParity.ReadOnly = true;
            this.textBoxVerHorParity.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxVerHorParity.Size = new System.Drawing.Size(666, 56);
            this.textBoxVerHorParity.TabIndex = 2;
            // 
            // textBoxCRC
            // 
            this.textBoxCRC.Location = new System.Drawing.Point(13, 259);
            this.textBoxCRC.Multiline = true;
            this.textBoxCRC.Name = "textBoxCRC";
            this.textBoxCRC.ReadOnly = true;
            this.textBoxCRC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCRC.Size = new System.Drawing.Size(666, 56);
            this.textBoxCRC.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Контроль по паритету";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Вертикальный и горизонтальный контроль по паритету";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Циклический избыточный контроль";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 367);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCRC);
            this.Controls.Add(this.textBoxVerHorParity);
            this.Controls.Add(this.textBoxParity);
            this.Controls.Add(this.buttonOpenFile);
            this.Name = "Form1";
            this.Text = "Гусев. А.А. 494. Лаб 3. Вариант - 4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.TextBox textBoxParity;
        private System.Windows.Forms.TextBox textBoxVerHorParity;
        private System.Windows.Forms.TextBox textBoxCRC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

