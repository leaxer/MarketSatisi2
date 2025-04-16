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