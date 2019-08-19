using BUS;
using DTO;
using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;

namespace Presentation
{
    public partial class frmThanhToan : MetroForm
    {
        int billID;
        string employeeName;
        int tableID;

        public frmThanhToan(int maHoaDon, int maBan, int maNhanVien)
        {
            InitializeComponent();
            billID = maHoaDon;
            tableID = maBan;
            employeeName = EmployeeBUS.GetEmployee(maNhanVien).HoTen;
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            DataTable billDetail = BillDetailBUS.LoadAllExtendedBillDetails(billID);
            billDetail.Columns[0].ColumnName = "ProductName";
            billDetail.Columns[1].ColumnName = "UnitPrice";
            billDetail.Columns[2].ColumnName = "Quantity";
            billDetail.Columns[3].ColumnName = "Total";
            HoaDon bill = BillBUS.GetBill(billID);

            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("pThoiGianLap", bill.ThoiGianLap.ToString()),
                new ReportParameter("pMaHoaDon", bill.MaHoaDon.ToString()),
                new ReportParameter("pMaBan", tableID.ToString()),
                new ReportParameter("pHoTen", employeeName)
            };

            reportViewer.LocalReport.SetParameters(parameters);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", billDetail));
            reportViewer.RefreshReport();
        }
    }
}
