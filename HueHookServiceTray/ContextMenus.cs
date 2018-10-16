using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.HueHookServiceTray
{
    public class ContextMenus
    {
        #region Member

        /// <summary>
		/// Is the About box displayed?
		/// </summary>
		bool isAboutLoaded = false;
        #endregion Member

        #region Properties


        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for ContextMenus
        /// </summary>
        public ContextMenus()
        {

        }

        #endregion Constructor

        #region Services
        /// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns>ContextMenuStrip</returns>
		public ContextMenuStrip Create()
        {
            // Add the default menu options.
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;
            ToolStripSeparator sep;

            // Start.
            item = new ToolStripMenuItem();
            item.Text = "Start server";
            item.Click += new EventHandler(Settings_Click);
            //item.Image = Properties.Resources.Explorer;
            menu.Items.Add(item);

            // Stop.
            item = new ToolStripMenuItem();
            item.Text = "Stop server";
            item.Click += new EventHandler(Settings_Click);
            //item.Image = Properties.Resources.Explorer;
            menu.Items.Add(item);

            // Separator.
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            // Settings.
            item = new ToolStripMenuItem();
            item.Text = "Settings";
            item.Click += new EventHandler(Settings_Click);
            //item.Image = Properties.Resources.Explorer;
            menu.Items.Add(item);

            // About.
            item = new ToolStripMenuItem();
            item.Text = "About";
            item.Click += new EventHandler(About_Click);
            //item.Image = Properties.Resources.About;
            menu.Items.Add(item);

            // Separator.
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            // Exit.
            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new System.EventHandler(Exit_Click);
            //item.Image = Properties.Resources.Exit;
            menu.Items.Add(item);

            menu.Opening += Menu_Opening;

            return menu;
        }

        private void Menu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            throw new NotImplementedException();
        }


        #endregion Services

        #region Internal services
        /// <summary>
        /// Handles the Click event of the Explorer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Settings_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", null);
        }

        /// <summary>
        /// Handles the Click event of the About control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void About_Click(object sender, EventArgs e)
        {
            if (!isAboutLoaded)
            {
                isAboutLoaded = true;
                new AboutBox().ShowDialog();
                isAboutLoaded = false;
            }
        }

        /// <summary>
        /// Processes a menu item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Exit_Click(object sender, EventArgs e)
        {
            // Quit without further ado.
            Application.Exit();
        }

        #endregion Internal services

        #region Events


        #endregion Events
    }
}
