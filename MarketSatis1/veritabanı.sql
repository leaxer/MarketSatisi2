create database marketsatis;
use marketsatis;

create table kasiyerler (
id int auto_increment primary key,
kasiyer_adi varchar(50) not null,
kasiyer_soyadi varchar(50) not null,
kasiyer_no int
);

CREATE TABLE urunler (
    id INT AUTO_INCREMENT PRIMARY KEY,
    urun_kodu VARCHAR(50) NOT NULL,
    urun_tanimi VARCHAR(255) NOT NULL,
    urun_adi VARCHAR(100) NOT NULL,
    urun_fiyati DECIMAL(10,2) NOT NULL,
    urun_adedi INT NOT NULL,
    urun_resmi LONGTEXT,
    UNIQUE (urun_kodu)
);

select * from urunler;

-- Siparisler tablosu
CREATE TABLE IF NOT EXISTS siparisler (
    siparis_id INT AUTO_INCREMENT PRIMARY KEY,
    siparis_tarihi DATETIME NOT NULL,
    toplam_tutar DECIMAL(10,2) NOT NULL,
    odeme_yontemi VARCHAR(20) NOT NULL
);

-- Siparis detaylari tablosu
CREATE TABLE IF NOT EXISTS siparis_detaylari (
    detay_id INT AUTO_INCREMENT PRIMARY KEY,
    siparis_id INT NOT NULL,
    urun_kodu VARCHAR(50) NOT NULL,
    adet INT NOT NULL,
    birim_fiyat DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (siparis_id) REFERENCES siparisler(siparis_id)
);

INSERT INTO kasiyerler (kasiyer_no, kasiyer_adi) VALUES
('1001', 'Ahmet'),
('1002', 'Mehmet'),
('1003', 'Ayşe');

INSERT INTO urunler (urun_kodu, urun_adi, urun_fiyati, urun_adedi, urun_tanimi) VALUES
('P001', 'Elma', 15.99, 100, 'Meyve'),
('P002', 'Ekmek', 5.00, 50, 'Fırın'),
('P003', 'Süt', 12.50, 75, 'Süt Ürünleri');