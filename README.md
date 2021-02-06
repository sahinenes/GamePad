### GamePad
### Araç ve Gereçler
- Atmega328p (Arduino)
- 4x4 keypad
- Atmel Studio
- Visual Studio 2019
- Not : Eğer Visual Studio programı bilgisayarınızda bulunmuyor ise Masaüstü Uygulaması Klasörünün Debug kısmında exe dosyası bulunmaktadır
### Amaç
- Arduino ve Keypad kullanılarak bilgisayar kontrolü
### Kullanım
- Serial Port (UART) kullanılarak bilgisayar ile iletişim sağlanmıştır.  
- Arduino yu kablo ile bilgisayara bağlayarak bulunduğu port u masaüstü uygulamasından seçiniz. Ve başlat butonu na basınız

![github](https://media.giphy.com/media/y9yXUdlgLC2ni3AxUn/giphy.gif)

- Keypad Tuş Sıralaması;

 - 1 2 3 
 - 4 5 6
 - 7 8 9
 -   0
   
  sağ taraftaki ve alttaki sağ sol ili buton kullanılmamıştır.
  
  ![github](https://media.giphy.com/media/kYZ4WT4hN2gk65HM0y/giphy.gif)
  
  - Masaüstü Uygulamasından 1 2 3 ve 5 butonlarına mouse ile sağ tıklayarak herhangi bir ses dosyası seçiniz.
  - Keypad in 1 2 3 ve 5 butonlarına bastığınızda bu parçalar çalmaya başlayacak.
  - Eğer 0 butonuna basarsınız duracaktır.
  - 4 ve 5 tuşuna bastığınızda uygulamalar arası geçiş yapabilirsiniz. (alt + tab )
  - 6 sistem sesini azaltır , 7 sistem sesini kapatır , 8 sistem sesini arttırır.
