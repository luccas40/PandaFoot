namespace PFDataEditor
{
    partial class mainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.leagueTitle = new System.Windows.Forms.Label();
            this.leaguesGrid = new System.Windows.Forms.DataGridView();
            this.teams = new System.Windows.Forms.DataGridView();
            this.teamTitle = new System.Windows.Forms.Label();
            this.players = new System.Windows.Forms.DataGridView();
            this.jogadoresTitle = new System.Windows.Forms.Label();
            this.loadXML = new System.Windows.Forms.Button();
            this.loadPanda = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Novo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.leaguesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.players)).BeginInit();
            this.SuspendLayout();
            // 
            // leagueTitle
            // 
            this.leagueTitle.AutoSize = true;
            this.leagueTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leagueTitle.Location = new System.Drawing.Point(11, 51);
            this.leagueTitle.Name = "leagueTitle";
            this.leagueTitle.Size = new System.Drawing.Size(174, 29);
            this.leagueTitle.TabIndex = 0;
            this.leagueTitle.Text = "Campeonatos";
            // 
            // leaguesGrid
            // 
            this.leaguesGrid.AllowUserToAddRows = false;
            this.leaguesGrid.AllowUserToDeleteRows = false;
            this.leaguesGrid.AllowUserToResizeRows = false;
            this.leaguesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.leaguesGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.leaguesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leaguesGrid.Location = new System.Drawing.Point(11, 83);
            this.leaguesGrid.MultiSelect = false;
            this.leaguesGrid.Name = "leaguesGrid";
            this.leaguesGrid.ReadOnly = true;
            this.leaguesGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.leaguesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.leaguesGrid.Size = new System.Drawing.Size(270, 150);
            this.leaguesGrid.TabIndex = 3;
            this.leaguesGrid.SelectionChanged += new System.EventHandler(this.campSelected);
            // 
            // teams
            // 
            this.teams.AllowUserToAddRows = false;
            this.teams.AllowUserToDeleteRows = false;
            this.teams.AllowUserToResizeRows = false;
            this.teams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.teams.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.teams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teams.Location = new System.Drawing.Point(287, 83);
            this.teams.MultiSelect = false;
            this.teams.Name = "teams";
            this.teams.ReadOnly = true;
            this.teams.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.teams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.teams.Size = new System.Drawing.Size(504, 150);
            this.teams.TabIndex = 5;
            this.teams.SelectionChanged += new System.EventHandler(this.teamSelected);
            // 
            // teamTitle
            // 
            this.teamTitle.AutoSize = true;
            this.teamTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamTitle.Location = new System.Drawing.Point(287, 51);
            this.teamTitle.Name = "teamTitle";
            this.teamTitle.Size = new System.Drawing.Size(86, 29);
            this.teamTitle.TabIndex = 4;
            this.teamTitle.Text = "Times";
            // 
            // players
            // 
            this.players.AllowUserToAddRows = false;
            this.players.AllowUserToDeleteRows = false;
            this.players.AllowUserToResizeRows = false;
            this.players.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.players.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.players.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.players.Location = new System.Drawing.Point(11, 280);
            this.players.MultiSelect = false;
            this.players.Name = "players";
            this.players.ReadOnly = true;
            this.players.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.players.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.players.Size = new System.Drawing.Size(780, 240);
            this.players.TabIndex = 7;
            // 
            // jogadoresTitle
            // 
            this.jogadoresTitle.AutoSize = true;
            this.jogadoresTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jogadoresTitle.Location = new System.Drawing.Point(11, 248);
            this.jogadoresTitle.Name = "jogadoresTitle";
            this.jogadoresTitle.Size = new System.Drawing.Size(137, 29);
            this.jogadoresTitle.TabIndex = 6;
            this.jogadoresTitle.Text = "Jogadores";
            // 
            // loadXML
            // 
            this.loadXML.Location = new System.Drawing.Point(395, 12);
            this.loadXML.Name = "loadXML";
            this.loadXML.Size = new System.Drawing.Size(89, 23);
            this.loadXML.TabIndex = 8;
            this.loadXML.Text = "Add XML";
            this.loadXML.UseVisualStyleBackColor = true;
            this.loadXML.Click += new System.EventHandler(this.loadXML_Click);
            // 
            // loadPanda
            // 
            this.loadPanda.Location = new System.Drawing.Point(490, 12);
            this.loadPanda.Name = "loadPanda";
            this.loadPanda.Size = new System.Drawing.Size(123, 23);
            this.loadPanda.TabIndex = 9;
            this.loadPanda.Text = "Carregar PandaBase";
            this.loadPanda.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(314, 12);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 10;
            this.Save.Text = "Salvar";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Novo
            // 
            this.Novo.Location = new System.Drawing.Point(233, 12);
            this.Novo.Name = "Novo";
            this.Novo.Size = new System.Drawing.Size(75, 23);
            this.Novo.TabIndex = 11;
            this.Novo.Text = "Novo";
            this.Novo.UseVisualStyleBackColor = true;
            this.Novo.Click += new System.EventHandler(this.Novo_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(804, 530);
            this.Controls.Add(this.Novo);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.loadPanda);
            this.Controls.Add(this.loadXML);
            this.Controls.Add(this.players);
            this.Controls.Add(this.jogadoresTitle);
            this.Controls.Add(this.teams);
            this.Controls.Add(this.teamTitle);
            this.Controls.Add(this.leaguesGrid);
            this.Controls.Add(this.leagueTitle);
            this.Name = "mainForm";
            this.Text = "DataEditor";
            ((System.ComponentModel.ISupportInitialize)(this.leaguesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.players)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label leagueTitle;
        public System.Windows.Forms.DataGridView leaguesGrid;
        public System.Windows.Forms.DataGridView teams;
        private System.Windows.Forms.Label teamTitle;
        public System.Windows.Forms.DataGridView players;
        private System.Windows.Forms.Label jogadoresTitle;
        private System.Windows.Forms.Button loadXML;
        private System.Windows.Forms.Button loadPanda;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Novo;
    }
}

