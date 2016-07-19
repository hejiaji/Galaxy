using EarthEscape.BaseClass;
using EarthEscape.Interface;
using EarthEscape.Interfaces;
using EarthEscape.Parsers;
using EarthEscape.Utils;
using EarthEscape.Utils.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace EarthEscape.Main
{
	public partial class Entry : System.Web.UI.Page
	{
        [Import]
        private IParserManager parserManager { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			initialization();
		}

		protected void btnTranslate_ServerClick(object sender, EventArgs e)
		{
			string input = txtInput.Value.Trim();
            string output = string.Empty;
            try
            {
                output = parserManager.Process(input);
                divOutput.InnerText = output;
            }
            catch (Exception ex)
            {
                output = Constant.noIdeaWhatYouAreTalkingAbout;
                divOutput.InnerText = Constant.noIdeaWhatYouAreTalkingAbout;
            }
            finally
            {
                if (string.IsNullOrEmpty(output))
                    divOutput.InnerText = Constant.noIdeaWhatYouAreTalkingAbout;
            }
		}

		#region initialization

		private void initialization()
		{
            InitializeIOC();
            DataInitialization.Initialize();
		}

        private void InitializeIOC()
        {
            var catalog = new AssemblyCatalog(typeof(Entry).Assembly);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }


		#endregion
	}
}