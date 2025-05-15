# 🏗️ Tower Test Calibration App

Aplikasi kalibrasi sensor beban (load cell) berbasis Windows Forms untuk keperluan pengujian tower dan alat uji lainnya. Menyediakan fitur pembacaan sensor Master & Slave, grafik pembanding, dan ekspor hasil ke PDF.

![Screenshot Aplikasi](screenshot.png) <!-- tambahkan jika ada -->

---

## 🔧 Fitur Utama

- 📊 Visualisasi data Master dan Slave dalam bentuk grafik
- 📝 Form kalibrasi lengkap dengan range otomatis (otomatis 10 titik)
- 📤 Ekspor hasil kalibrasi ke PDF (dengan grafik dan tanda tangan)
- 🌐 Pengecekan versi otomatis & auto-update dari GitHub
- 🔌 Komunikasi real-time dengan alat via Serial Port
- 👥 Dukungan multi tahap input kalibrasi (Master1/Slave1 → Master2/Slave2)

---

## 🖥️ Spesifikasi Minimum

- Windows 10 / 11
- .NET Framework 4.7.2 atau lebih tinggi
- RAM 4GB+
- Port USB/Serial aktif untuk koneksi alat
- Port LAN

---

## 🚀 Cara Menggunakan

1. Jalankan `TesTowerApp.exe`
2. Masukkan nilai `Max Load` → tabel otomatis terisi 10 titik range
3. Hubungkan alat kalibrasi ke port serial
4. Klik **Tambah Data** untuk mulai input hasil Master dan Slave
5. Setelah selesai, ekspor hasilnya ke PDF dengan klik **Export PDF**
6. Gunakan tombol **Update** untuk memastikan aplikasi selalu versi terbaru

---

## 📦 Instalasi

Unduh file `.msi` dari [Releases](https://github.com/qoryrmnd/towertestprogrambkk/releases) lalu jalankan untuk instalasi.

---

## 🆕 Auto-Update

Setiap aplikasi dijalankan, akan dicek apakah versi terbaru tersedia dari:

- [`version.txt`](https://github.com/qoryrmnd/towertestprogrambkk/blob/main/version.txt)
- Jika ada versi baru, maka aplikasi akan otomatis mengunduh dan menjalankan installer.

---

## 📁 Struktur Proyek (Singkat)

```plaintext
/Forms              # Semua form Windows
/Helpers            # Fungsi pembantu
/Models             # Struktur data (jika ada)
/Export             # Fungsi ekspor PDF
/Update             # Logika update otomatis

## 🤝 Kontribusi
Pull request dan issue sangat terbuka.
Jika ingin ikut berkontribusi atau menambahkan fitur baru, silakan fork dan kirim PR.

---

## 📃 Lisensi
MIT License © 2025 Qory Rohman Dewa
Bebas digunakan, dimodifikasi, dan dikembangkan lebih lanjut.

---
