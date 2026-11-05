using System.Reflection;
using CafeApp.Services;
using Xunit;

public class MessagesTests
{
    // Lấy mọi thông báo kiểu string của lớp Messages (kể cả khi sau này thêm hằng mới)
    private static List<(string Name, string Value)> AllMessages()
    {
        return typeof(Messages)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == typeof(string))
            .Select(f => (f.Name, (string)(f.GetValue(null) ?? "")))
            .ToList();
    }

    [Fact]
    public void Messages_CoThongBao()
    {
        Assert.NotEmpty(AllMessages());
    }

    [Fact]
    public void MoiThongBao_KhongRong()
    {
        foreach (var (name, value) in AllMessages())
            Assert.False(string.IsNullOrWhiteSpace(value), $"Thông báo {name} bị rỗng");
    }

    [Fact]
    public void ThongBaoDangNhapSai_DungNoiDung()
    {
        Assert.Equal("Email hoặc mật khẩu không đúng!", Messages.InvalidLogin);
        Assert.Contains("không đúng", Messages.InvalidLogin);
    }

    [Fact]
    public void ThongBaoBaristaDaTonTai_DungNoiDung()
    {
        Assert.Equal("Barista này đã được thêm", Messages.BaristaExists);
        Assert.Contains("đã được thêm", Messages.BaristaExists);
    }

    [Fact]
    public void KhongConThongBaoTiengAnhCu()
    {
        string[] chuoiCu = { "Invalid email or password", "already added" };

        foreach (var (name, value) in AllMessages())
            foreach (var cu in chuoiCu)
                Assert.DoesNotContain(cu, value, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void ThongBao_CoChuTiengVietCoDau()
    {
        // Phát hiện lỗi vỡ dấu (ví dụ file lưu sai encoding)
        foreach (var (name, value) in AllMessages())
            Assert.DoesNotContain("�", value);
    }
}