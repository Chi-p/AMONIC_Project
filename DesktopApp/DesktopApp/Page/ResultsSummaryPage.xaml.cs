using DesktopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp.Page
{
    /// <summary>
    /// Interaction logic for ResultsSummaryPage.xaml
    /// </summary>
    public partial class ResultsSummaryPage
    {
        private StringBuilder result;
        private List<Surveys> _surveysList;

        public ResultsSummaryPage()
        {
            InitializeComponent();

            Load();
        }

        private void Load()
        {
            result = new StringBuilder();
            _surveysList = AppData.Context.Surveys.ToList();

            //Основные теги
            result.Append("<html>");
            result.Append("<meta charset=utf-8>");
            result.Append("<style>");
            result.Append(".leftstr, .rightstr { float: left; width: 50%; }");
            result.Append("</style>");
            result.Append("<body>");

            result.Append("<div>");
            result.Append("<p align=left class=leftstr> <b>Fieldwork: June 2017 - October 2017</b> </p>");
            result.Append($"<p align=right class=rightstr> <b>Sample Size {_surveysList.Count()} Adults</b> </p>");
            result.Append("</div>");
            result.Append("<hr size=1 color=black />");

            //Закрывающие
            result.Append("</body>");
            result.Append("</html>");

            WebBr.NavigateToString(result.ToString());
        }

        private void WebBr_LoadCompleted(object sender, NavigationEventArgs e)
        {
            WebBr.InvokeScript("execScript", new Object[] { "document.body.style.overflow ='hidden'", "JavaScript" });
        }
    }
}
