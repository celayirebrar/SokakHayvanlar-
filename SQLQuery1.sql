UPDATE dbo.Kullanicilar
SET Rol = N'Yonetici'
WHERE KullaniciID = 1;
SELECT KullaniciID, AdSoyad, KullaniciAdi, Rol, Aktif
FROM dbo.Kullanicilar;