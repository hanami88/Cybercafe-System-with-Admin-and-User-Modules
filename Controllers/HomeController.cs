using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using netmvc.Models;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Trangchu(){
       ViewBag.check = false;
        return View();
    }
    [HttpPost]
    public IActionResult Trangchu(TaiKhoan temp){
        List<TaiKhoan> a=_context.TaiKhoan.ToList();
        foreach(var i in a){
            if(i.Tendangnhap==temp.Tendangnhap&&i.Matkhau==temp.Matkhau){
                if(i.Quyen==1){
                    return RedirectToAction("Quanly","Home");
                }
                else{
                    TempData["ID"] = i.ID;
                    return RedirectToAction("Nguoidung","Home");
                }
            }
        }
        ViewBag.check = true;
        return View();
    }
    public IActionResult Dangky(){
        return View();
    }
    [HttpPost]
    public IActionResult Dangky(string Tendangnhap,string Matkhau,string XacNhanMatkhau,string SDT,string Hoten,int Quyen,string Sodu){
        List<TaiKhoan> a=_context.TaiKhoan.ToList();
        foreach(var i in a){
            if(i.Tendangnhap==Tendangnhap){
                ViewBag.error="Tên đăng nhập đã tồn tại";
                return View();
            }
        }
        if(XacNhanMatkhau!=Matkhau){
            ViewBag.error="Mật khẩu không khớp";
            return View();
        }
        TaiKhoan tk=new TaiKhoan();
        tk.Hoten=Hoten;
        tk.Matkhau=Matkhau;
        tk.Tendangnhap=Tendangnhap;
        tk.SDT=SDT;
        tk.Quyen=Quyen;
        tk.Sodu=Sodu;
        _context.TaiKhoan.Add(tk);
        _context.SaveChanges();
        return RedirectToAction("Trangchu","Home");
    }
    public IActionResult Quanly(){
        List<MayTinh> a=_context.MayTinh.ToList();
        return View(a);
    }
    public IActionResult Quanlynguoidung(){
        List<TaiKhoan> a=_context.TaiKhoan.ToList();
        return View(a);
    }
    [HttpPost]
     public IActionResult Deletenguoidung(string ID)
    {
    var may = _context.TaiKhoan.FirstOrDefault(m => m.ID.ToString() == ID);
    if (may != null)
    {
        _context.TaiKhoan.Remove(may);
        _context.SaveChanges();
    }
    return RedirectToAction("Quanlynguoidung","Home");
    }

    [HttpPost]
    public IActionResult Suathongtinnguoidung(int ID,string Tendangnhap,string Hoten,string SDT,string Matkhau,string Sodu)
    {   
        List<TaiKhoan> a=_context.TaiKhoan.ToList();
        foreach(var i in a){
        if(i.Tendangnhap==Tendangnhap&&i.ID!=ID){
            ViewBag.ID=ID;
            ViewBag.error="Tên đăng nhập bị trùng";
            return View(a);
        }
        }
       foreach(var i in a){
        if(i.ID==ID){
            i.Tendangnhap = Tendangnhap;
            i.SDT = SDT;
            i.Hoten = Hoten;
            i.Matkhau = Matkhau;
            i.Sodu = Sodu;
            _context.SaveChanges();
            return RedirectToAction("Quanlynguoidung");
        }
    }
    ViewBag.error="ID không hợp lệ";
    return View();
    }
    public IActionResult Nguoidung()
    {   
    if((string)TempData["Hettien"]=="1"){
         ViewBag.Hettien="Tài khoản của bạn không đủ tiền :))";
    }
    ViewBag.ID =TempData["ID"]?.ToString();
    List<MayTinh> a = _context.MayTinh.ToList();
    ViewBag.TaiKhoan = _context.TaiKhoan.ToList();
    return View(a);
    }
    public IActionResult Themmaytinh(){
        return View();
    }

    [HttpPost]
     public IActionResult Delete(int ID)
    {
    var may = _context.MayTinh.FirstOrDefault(m => m.ID == ID);
    if (may != null)
    {
        _context.MayTinh.Remove(may);
        _context.SaveChanges();
    }
    return RedirectToAction("Quanly","Home");
    }

    [HttpPost]
     public IActionResult Themmaytinh(string Tenmay,string dongia)
    {
        List<MayTinh> a=_context.MayTinh.ToList();
        foreach(var i in a){
            if(i.Tenmay==Tenmay){
              ViewBag.error="Tên máy bị trùng";
              return View();
            }
        }
        MayTinh may=new MayTinh();
        may.Tenmay=Tenmay;
        may.Trangthai="Rảnh";
        may.dongia=dongia;
        may.Doanhthu="0";
        if (may != null)
        {
        _context.MayTinh.Add(may);
        _context.SaveChanges();
        }
        return RedirectToAction("Quanly");
    }
    [HttpPost]
    public IActionResult Suathongtinnguoidungtmp(string ID){
        TempData["id"]=ID;
        return RedirectToAction("Suathongtinnguoidung","Home");
    }
    public IActionResult Suathongtinnguoidung(){
        ViewBag.ID = TempData["id"].ToString();
        List<TaiKhoan> a=_context.TaiKhoan.ToList();
        return View(a);
    }
    [HttpPost]
    public IActionResult Suathongtinmaytinhtmp(string ID){
        TempData["ID"]=ID;
        return RedirectToAction("Suathongtinmaytinh","Home");
    }
    public IActionResult Suathongtinmaytinh(){
        ViewBag.ID = TempData["ID"].ToString();
        List<MayTinh> a=_context.MayTinh.ToList();
        return View(a);
    }
    [HttpPost]
    public IActionResult Suathongtinmaytinh(int ID,string Tenmay, string dongia)
    {   
        List<MayTinh> a=_context.MayTinh.ToList();
        foreach(var i in a){
        if(i.Tenmay==Tenmay&&i.ID!=ID){
            ViewBag.ID = ID;
            ViewBag.error="Tên máy bị trùng";
            return View(a);
        }
    }
    foreach(var i in a){
        if(i.ID==ID){
            i.Tenmay = Tenmay;
            i.dongia = dongia;
            _context.SaveChanges();
            return RedirectToAction("Quanly");
        }
    }
    ViewBag.error="ID không hợp lệ";
    return View();
   }
   [HttpPost]
   public IActionResult ChoiGame(int IDnguoichoi,int IDmaytinh){
    TempData["Hettien"] ="0";
    List<TaiKhoan> a=_context.TaiKhoan.ToList();
    List<MayTinh> b=_context.MayTinh.ToList();
    foreach(var i in a){
        if(IDnguoichoi == i.ID){
            ViewBag.SoDuNguoiDung=i.Sodu;
            if(i.Sodu=="0"){
                TempData["Hettien"] ="1";
                TempData["ID"] =i.ID;
                return RedirectToAction("Nguoidung","Home");
            }
        }
    }
    foreach(var i in b){
        if(IDmaytinh == i.ID){
            ViewBag.DonGiaMayTinh=i.dongia;
        }
    }
    var sudung = new SuDungMayTinh
    {
        IDnguoidung = IDnguoichoi,
        IDmaytinh = IDmaytinh,
         Giobatdau= DateTime.Now,
    };
    _context.SuDungMayTinh.Add(sudung);
    _context.SaveChanges();
    ViewBag.IDnguoichoi=IDnguoichoi;
    ViewBag.IDmaytinh=IDmaytinh;
    return View();
   }
   [HttpPost]
    public IActionResult KetThucSuDung(int IDnguoidung, int IDmaytinh)
{
    var sudung = _context.SuDungMayTinh
        .FirstOrDefault(x => x.IDnguoidung == IDnguoidung && x.IDmaytinh == IDmaytinh && x.Gioketthuc == null);
    if (sudung == null)
    {
        return NotFound();
    }
    sudung.Gioketthuc = DateTime.Now;
    TimeSpan duration = sudung.Gioketthuc.Value - sudung.Giobatdau;
    double soGio = duration.TotalMinutes / 60.0;
    var may = _context.MayTinh.FirstOrDefault(m => m.ID == IDmaytinh);
    if (may == null)
    {
        return NotFound();
    }
    long donGia = 0;
    if (!string.IsNullOrEmpty(may.dongia))
    {
        var donGiaClean = may.dongia.Replace(".", "").Replace(",", "").Replace("d/h", "").Replace("đ/h", "").Trim();
        long.TryParse(donGiaClean, out donGia);
    }
    long doanhthuHienTai = 0;
    if (!string.IsNullOrEmpty(may.Doanhthu))
    {
        var doanhThuClean = may.Doanhthu.Replace(".", "").Replace(",", "").Trim();
        long.TryParse(doanhThuClean, out doanhthuHienTai);
    }
    long tongTien = (long)(donGia * soGio);
    long doanhThuTuongLai = doanhthuHienTai + tongTien;
    var nguoidung = _context.TaiKhoan.FirstOrDefault(u => u.ID == IDnguoidung);
    if (nguoidung == null)
    {
        return NotFound();
    }
    long soDu = 0;
    if (!string.IsNullOrEmpty(nguoidung.Sodu))
    {
        var soDuClean = nguoidung.Sodu.Replace(".", "").Replace(",", "").Trim();
        long.TryParse(soDuClean, out soDu);
    }
    soDu -= tongTien;
    if (soDu < 0) soDu = 0;
    may.Doanhthu = String.Format("{0:N0}", doanhThuTuongLai);
    nguoidung.Sodu = String.Format("{0:N0}", soDu);
    _context.SuDungMayTinh.Update(sudung);
    _context.MayTinh.Update(may);
    _context.TaiKhoan.Update(nguoidung);
    _context.SaveChanges();
    TempData["ID"] = IDnguoidung;
    return RedirectToAction("Nguoidung", "Home");
}

  [HttpPost]
  public IActionResult Naptien(string tien, string ID)
   {
    List<TaiKhoan> a = _context.TaiKhoan.ToList();
    var user = a.FirstOrDefault(x => x.ID == Convert.ToInt32(ID)); 
    if (user != null)
    {
        var soDuHienTai = Convert.ToInt64(user.Sodu.Replace(",", ""));
        var soTienNaptien = Convert.ToInt64(tien);
        var tongTien = soDuHienTai + soTienNaptien;
        user.Sodu = String.Format("{0:N0}", tongTien);
        _context.Update(user);
        _context.SaveChanges();
    }
    TempData["ID"]=ID;
    return RedirectToAction("Nguoidung","Home");
    }
    public IActionResult Doanhthu(){
        List<MayTinh> a=_context.MayTinh.ToList();
        return View(a);
    }
    [HttpGet]
    public IActionResult Naptien(int ID){
    ViewBag.ID=ID;
    return View();
    }
}
