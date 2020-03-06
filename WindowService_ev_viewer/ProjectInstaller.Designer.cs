namespace MyCoolService
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mycoolserviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.mycoolserviceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // mycoolserviceProcessInstaller
            // 
            this.mycoolserviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.mycoolserviceProcessInstaller.Password = null;
            this.mycoolserviceProcessInstaller.Username = null;
            // 
            // mycoolserviceInstaller
            // 
            this.mycoolserviceInstaller.Description = "hi";
            this.mycoolserviceInstaller.ServiceName = "MyCoolService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.mycoolserviceProcessInstaller,
            this.mycoolserviceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller mycoolserviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller mycoolserviceInstaller;
    }
}