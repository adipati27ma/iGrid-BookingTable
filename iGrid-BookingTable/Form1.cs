using TenTec.Windows.iGridLib;

namespace iGrid_BookingTable;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    #region The designer fields
    private iGrid fGrid;
    #endregion

    iGColHdrStyle fHolidayHdrStyle = new iGColHdrStyle();
    iGColHdrStyle fWorkdayHdrStyle = new iGColHdrStyle();
    iGColHdrStyle fWeekNoHdrStyle = new iGColHdrStyle();


    private void Form1_Load(object sender, System.EventArgs e)
    {
        #region Set up the header properties.
        // Do not draw the header by using system styles (XP and 3D).
        //fGrid.Header.DrawSystem = false; // default from code example
        //fGrid.Header.UseXPStyles = false;

        // Show the header grid lines.
        fGrid.Header.VGridLinesStyle.Width = 1;
        fGrid.Header.HGridLinesStyle.Width = 1;

        // Set up the geader background color.
        fGrid.Header.BackColor = SystemColors.ControlLightLight;

        // Prohibit sorting of the columns.
        fGrid.Header.AllowPress = false;

        // Prohibit hot column header indication.
        //fGrid.Header.HotTrackFlags = iGHdrHotTrackFlags.None; // default from code example
        //fGrid.Header.HotTrackFlagsXPStyles = iGHdrHotTrackFlags.None;
        //fGrid.Header.HotTrackFlagsStyle3D = iGHdrHotTrackFlags.None;
        #endregion

        #region Set up the header cell styles
        fHolidayHdrStyle.TextFormatFlags = iGStringFormatFlags.DirectionVertical | iGStringFormatFlags.Rotate180;
        fHolidayHdrStyle.Font = new Font(fGrid.Font, FontStyle.Bold);
        fHolidayHdrStyle.BackColor = Color.LightGray;
        fHolidayHdrStyle.FormatString = "{0:ddd-dd-MMM}";
        fHolidayHdrStyle.TextAlign = iGContentAlignment.MiddleCenter;

        fWorkdayHdrStyle.TextFormatFlags = iGStringFormatFlags.DirectionVertical | iGStringFormatFlags.Rotate180;
        fWorkdayHdrStyle.Font = new Font(fGrid.Font, FontStyle.Bold);
        fWorkdayHdrStyle.BackColor = Color.Magenta;
        fWorkdayHdrStyle.FormatString = "{0:ddd-dd-MMM}";
        fHolidayHdrStyle.TextAlign = iGContentAlignment.MiddleCenter;

        fWeekNoHdrStyle.TextAlign = iGContentAlignment.MiddleCenter;
        fWeekNoHdrStyle.BackColor = SystemColors.Window;
        #endregion

        // Add a row to the header.
        fGrid.Header.Rows.Add(1);

        // Add columns.
        fGrid.DefaultCol.Width = 20;
        fGrid.DefaultCol.CellStyle.Font = new Font(fGrid.Font, FontStyle.Bold);
        fGrid.Cols.AddRange(16);

        // Set the first column to be non-scrollable.
        fGrid.FrozenArea.ColCount = 1;

        // Set up the first column's cell style.
        fGrid.Cols[0].CellStyle.BackColor = SystemColors.ControlLightLight;
        fGrid.Cols[0].CellStyle.TextAlign = iGContentAlignment.MiddleRight;
        fGrid.Cols[0].CellStyle.Font = fGrid.Font;

        // Merge the header cells in the first column.
        fGrid.Header.Cells[0, 0].SpanRows = 2;
        // Set up the text of the first column's header.
        fGrid.Header.Cells[0, 0].Value = "Cabins Last Updated\r\n28-Feb-05\r\n06-42 AM";
        fGrid.Header.Cells[0, 0].TextAlign = iGContentAlignment.MiddleCenter;

        #region Set up the header cells
        SetupWeekendHeader(1, new DateTime(2005, 2, 26));

        SetupWeekNumber(2, 10);
        SetupWorkdayHeader(2, new DateTime(2005, 2, 27));
        SetupWorkdayHeader(3, new DateTime(2005, 2, 28));
        SetupWorkdayHeader(4, new DateTime(2005, 2, 1));
        SetupWorkdayHeader(5, new DateTime(2005, 3, 2));
        SetupWorkdayHeader(6, new DateTime(2005, 3, 3));

        SetupWeekendHeader(7, new DateTime(2005, 3, 4));
        SetupWeekendHeader(8, new DateTime(2005, 3, 5));

        SetupWeekNumber(9, 11);
        SetupWorkdayHeader(9, new DateTime(2005, 3, 6));
        SetupWorkdayHeader(10, new DateTime(2005, 3, 7));
        SetupWorkdayHeader(11, new DateTime(2005, 2, 8));
        SetupWorkdayHeader(12, new DateTime(2005, 3, 9));
        SetupWorkdayHeader(13, new DateTime(2005, 3, 10));

        SetupWeekendHeader(14, new DateTime(2005, 3, 11));
        SetupWeekendHeader(15, new DateTime(2005, 3, 12));
        #endregion

        // Add rows.
        fGrid.DefaultRow.Height = fGrid.GetPreferredRowHeight(true, false);
        fGrid.Rows.AddRange(4);

        #region Fill the rows' cells
        fGrid.Cells[0, 0].Value = "House on Beach M40 (7)";
        fGrid.Cells[0, 5].Value = "S";
        SetupCellsColor(0, 5, 5, Color.SkyBlue);

        fGrid.Cells[1, 0].Value = "BF Motel M23 (5)";
        fGrid.Cells[1, 0].BackColor = Color.FromArgb(241, 175, 72);
        fGrid.Cells[1, 1].Value = "X";
        fGrid.Cells[1, 2].Value = "0";
        SetupCellsColor(1, 1, 7, Color.FromArgb(233, 166, 185));
        SetupCellsColor(1, 8, 2, Color.SkyBlue);

        fGrid.Cells[2, 0].Value = "Motel M21 (4)";
        fGrid.Cells[2, 0].BackColor = Color.FromArgb(199, 174, 231);
        fGrid.Cells[2, 1].Value = "X";
        fGrid.Cells[2, 2].Value = "X";
        SetupCellsColor(2, 1, 2, Color.FromArgb(233, 166, 185));
        SetupCellsColor(2, 3, 7, Color.Yellow);

        fGrid.Cells[3, 0].Value = "Motel M22 (3)";
        fGrid.Cells[3, 0].BackColor = Color.FromArgb(199, 174, 231);
        fGrid.Cells[3, 1].Value = "X";
        fGrid.Cells[3, 2].Value = "X";
        SetupCellsColor(3, 1, 2, Color.FromArgb(233, 166, 185));
        SetupCellsColor(3, 3, 6, Color.Yellow);
        SetupCellsColor(3, 9, 6, Color.LightGreen);
        #endregion

        // Adjust the width of the first column.
        fGrid.Cols[0].AutoWidth();
    }

    void SetupWeekNumber(int firstDayColIndex, int weekNumber)
    {
        iGColHdr myColHdr = fGrid.Header.Cells[0, firstDayColIndex];

        // Merge header cells.
        myColHdr.SpanCols = 5;

        // Assign a text to the merged header cell.
        myColHdr.Value = "WeekNo " + weekNumber.ToString();

        // Assign a style to the merged header cell. The style determines 
        // the appearance of the header cell.
        myColHdr.Style = fWeekNoHdrStyle;
    }

    void SetupWeekendHeader(int colIndex, DateTime date)
    {
        iGColHdr myColHdr = fGrid.Header.Cells[1, colIndex];

        // Assign a style to the header cell. The style determines 
        // the appearance of the header cell.
        myColHdr.Style = fHolidayHdrStyle;

        // Assign the date to be displayed to the header cell.
        myColHdr.Value = date;

        // Adjust the column background color.
        fGrid.Header.Cells[0, colIndex].BackColor = fHolidayHdrStyle.BackColor;
        fGrid.Cols[colIndex].CellStyle.BackColor = fHolidayHdrStyle.BackColor;
    }

    void SetupWorkdayHeader(int colIndex, DateTime date)
    {
        iGColHdr myColHdr = fGrid.Header.Cells[1, colIndex];

        // Assign a style to the header cell. The style determines 
        // the appearance of the header cell.
        myColHdr.Style = fWorkdayHdrStyle;

        // Assign the date to be displayed to the header cell.
        myColHdr.Value = date;
    }

    void SetupCellsColor(int rowIndex, int colIndex, int count, Color color)
    {
        // Create a style with the specified background color.
        // This style will be assigned to the cells to be filled
        // with the specified color.
        iGCellStyle myStyle = new iGCellStyle();
        myStyle.BackColor = color;

        // Assign the created style to the specified cell range.
        for (int myColIndex = colIndex; myColIndex < colIndex + count; myColIndex++)
            fGrid.Cells[rowIndex, myColIndex].Style = myStyle;
    }
}