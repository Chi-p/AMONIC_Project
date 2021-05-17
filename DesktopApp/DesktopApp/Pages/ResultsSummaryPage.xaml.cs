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

namespace DesktopApp.Pages
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
            _surveysList = AppData.Context.Surveys.ToList().OrderBy(i => i.Date).ToList();

            #region html

            #region Основные теги
            result.Append("<html>");
            result.Append("<meta charset=utf-8>");
            result.Append("<style>");
            result.Append(".leftstr, .rightstr { float: left; width: 50%; }");
            result.Append("</style>");
            result.Append("<body>");
            #endregion

            #region Строка с информацией
            result.Append("<div>");
            result.Append($"<p align=left class=leftstr> <b>Fieldwork: " +
                $"{_surveysList.First().Date:MMMM yyyy} - {_surveysList.Last().Date:MMMM yyyy}</b> </p>");
            result.Append($"<p align=right class=rightstr> <b>Sample Size {_surveysList.Count()} Adults</b> </p>");
            result.Append("</div>");
            result.Append("<hr size=1 color=black />");
            #endregion

            #region Таблица
            result.Append("<table width=100% border=1 bordercolor=black style='border-collapse:collapse'>");

            #region 1 заголовок
            result.Append("<tr>");
            result.Append("<td align=center colspan=2> <b>Gender</b> </td>");
            result.Append("<td align=center colspan=4> <b>Age</b> </td>");
            result.Append("<td align=center colspan=3> <b>Cabin Type</b> </td>");
            result.Append("<td align=center colspan=6> <b>Destination Airport</b> </td>");
            result.Append("</tr>");
            #endregion

            #region 2 заголовок
            result.Append("<tr>");
            result.Append("<td align=center> <b>Male</b> </td>");
            result.Append("<td align=center> <b>Female</b> </td>");
            result.Append("<td align=center> <b>18-24</b> </td>");
            result.Append("<td align=center> <b>25-39</b> </td>");
            result.Append("<td align=center> <b>40-59</b> </td>");
            result.Append("<td align=center> <b>60+</b> </td>");
            result.Append("<td align=center> <b>Economy</b> </td>");
            result.Append("<td align=center> <b>Business</b> </td>");
            result.Append("<td align=center> <b>First</b> </td>");
            result.Append("<td align=center> <b>AUH</b> </td>");
            result.Append("<td align=center> <b>CAI</b> </td>");
            result.Append("<td align=center> <b>BAH</b> </td>");
            result.Append("<td align=center> <b>ADE</b> </td>");
            result.Append("<td align=center> <b>DOH</b> </td>");
            result.Append("<td align=center> <b>RUH</b> </td>");
            result.Append("</tr>");
            #endregion

            #region Данные
            result.Append("<tr>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.GenderCode == "M").Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.GenderCode == "F").Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.Age >= 18 && i.Age <= 24).Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.Age >= 25 && i.Age <= 39).Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.Age >= 40 && i.Age <= 59).Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.Age >= 60).Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.CabinTypeId == 1).Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.CabinTypeId == 2).Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.CabinTypeId == 3).Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.DepartureId == 2).Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.DepartureId == 3).Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.DepartureId == 4).Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.DepartureId == 5).Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.DepartureId == 6).Count()} </td>");
            result.Append($"<td align=center> {_surveysList.Where(i => i.DepartureId == 7).Count()} </td>");
            result.Append("</tr>");
            #endregion

            result.Append("</table>");
            #endregion

            #region Закрывающие
            result.Append("</body>");
            result.Append("</html>");
            #endregion

            #endregion

            WBMain.NavigateToString(result.ToString());
        }

        private void WebBr_LoadCompleted(object sender, NavigationEventArgs e)
        {
            WBMain.InvokeScript("execScript", new Object[] { "document.body.style.overflow ='hidden'", "JavaScript" });
        }
    }
}
