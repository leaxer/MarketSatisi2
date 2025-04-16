create database marketsatis;
use marketsatis;

CREATE TABLE urunler (
    id INT AUTO_INCREMENT PRIMARY KEY,
    urun_kodu VARCHAR(50) NOT NULL,
    urun_tanimi VARCHAR(255) NOT NULL,
    urun_adi VARCHAR(100) NOT NULL,
    urun_fiyati DECIMAL(10,2) NOT NULL,
    urun_adedi INT NOT NULL
);

select * from urunler;

-- Siparişler tablosu
CREATE TABLE IF NOT EXISTS siparisler (
    siparis_id INT AUTO_INCREMENT PRIMARY KEY,
    siparis_tarihi DATETIME NOT NULL,
    toplam_tutar DECIMAL(10,2) NOT NULL,
    odeme_yontemi VARCHAR(20) NOT NULL
);

-- Sipariş detayları tablosu
CREATE TABLE IF NOT EXISTS siparis_detaylari (
    detay_id INT AUTO_INCREMENT PRIMARY KEY,
    siparis_id INT NOT NULL,
    urun_kodu VARCHAR(50) NOT NULL,
    adet INT NOT NULL,
    birim_fiyat DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (siparis_id) REFERENCES siparisler(siparis_id)
);