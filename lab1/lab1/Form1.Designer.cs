namespace lab2
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.aeroDataSet1 = new lab1.aeroDataSet1();
            this.tripBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tripTableAdapter = new lab1.aeroDataSet1TableAdapters.TripTableAdapter();
            this.tripnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDcompDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.townfromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.towntoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeoutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aeroDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tripBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tripnoDataGridViewTextBoxColumn,
            this.iDcompDataGridViewTextBoxColumn,
            this.planeDataGridViewTextBoxColumn,
            this.townfromDataGridViewTextBoxColumn,
            this.towntoDataGridViewTextBoxColumn,
            this.timeoutDataGridViewTextBoxColumn,
            this.timeinDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tripBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(776, 237);
            this.dataGridView1.TabIndex = 0;
            // 
            // aeroDataSet1
            // 
            this.aeroDataSet1.DataSetName = "aeroDataSet1";
            this.aeroDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tripBindingSource
            // 
            this.tripBindingSource.DataMember = "Trip";
            this.tripBindingSource.DataSource = this.aeroDataSet1;
            // 
            // tripTableAdapter
            // 
            this.tripTableAdapter.ClearBeforeFill = true;
            // 
            // tripnoDataGridViewTextBoxColumn
            // 
            this.tripnoDataGridViewTextBoxColumn.DataPropertyName = "trip_no";
            this.tripnoDataGridViewTextBoxColumn.HeaderText = "trip_no";
            this.tripnoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tripnoDataGridViewTextBoxColumn.Name = "tripnoDataGridViewTextBoxColumn";
            this.tripnoDataGridViewTextBoxColumn.Width = 125;
            // 
            // iDcompDataGridViewTextBoxColumn
            // 
            this.iDcompDataGridViewTextBoxColumn.DataPropertyName = "ID_comp";
            this.iDcompDataGridViewTextBoxColumn.HeaderText = "ID_comp";
            this.iDcompDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDcompDataGridViewTextBoxColumn.Name = "iDcompDataGridViewTextBoxColumn";
            this.iDcompDataGridViewTextBoxColumn.Width = 125;
            // 
            // planeDataGridViewTextBoxColumn
            // 
            this.planeDataGridViewTextBoxColumn.DataPropertyName = "plane";
            this.planeDataGridViewTextBoxColumn.HeaderText = "plane";
            this.planeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.planeDataGridViewTextBoxColumn.Name = "planeDataGridViewTextBoxColumn";
            this.planeDataGridViewTextBoxColumn.Width = 125;
            // 
            // townfromDataGridViewTextBoxColumn
            // 
            this.townfromDataGridViewTextBoxColumn.DataPropertyName = "town_from";
            this.townfromDataGridViewTextBoxColumn.HeaderText = "town_from";
            this.townfromDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.townfromDataGridViewTextBoxColumn.Name = "townfromDataGridViewTextBoxColumn";
            this.townfromDataGridViewTextBoxColumn.Width = 125;
            // 
            // towntoDataGridViewTextBoxColumn
            // 
            this.towntoDataGridViewTextBoxColumn.DataPropertyName = "town_to";
            this.towntoDataGridViewTextBoxColumn.HeaderText = "town_to";
            this.towntoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.towntoDataGridViewTextBoxColumn.Name = "towntoDataGridViewTextBoxColumn";
            this.towntoDataGridViewTextBoxColumn.Width = 125;
            // 
            // timeoutDataGridViewTextBoxColumn
            // 
            this.timeoutDataGridViewTextBoxColumn.DataPropertyName = "time_out";
            this.timeoutDataGridViewTextBoxColumn.HeaderText = "time_out";
            this.timeoutDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.timeoutDataGridViewTextBoxColumn.Name = "timeoutDataGridViewTextBoxColumn";
            this.timeoutDataGridViewTextBoxColumn.Width = 125;
            // 
            // timeinDataGridViewTextBoxColumn
            // 
            this.timeinDataGridViewTextBoxColumn.DataPropertyName = "time_in";
            this.timeinDataGridViewTextBoxColumn.HeaderText = "time_in";
            this.timeinDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.timeinDataGridViewTextBoxColumn.Name = "timeinDataGridViewTextBoxColumn";
            this.timeinDataGridViewTextBoxColumn.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aeroDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tripBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private lab1.aeroDataSet1 aeroDataSet1;
        private System.Windows.Forms.BindingSource tripBindingSource;
        private lab1.aeroDataSet1TableAdapters.TripTableAdapter tripTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn tripnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDcompDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn townfromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn towntoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeoutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeinDataGridViewTextBoxColumn;
    }
}

