# CoreDemo
Geniş kapsamlı bir blog sitesi projesi. Murat Yücedağ hocamızın youtube üzerinden yayınladığı Asp.Net Core 5.0 Proje Kampı projesi ile beraber yapılmaktadır.
Kayıt olma,giriş yapma gibi özellikler vardır.Giriş yapan yazar,blog ekleyebilir,bloglarını düzenleyebilir veya silebilir.Ayrıca projemiz bir admin paneline sahip olacaktır.

## 1-) ANA SAYFA
### Layout
#### Header Kısmı
Giriş yap ve kayıt olma işlemlerini gerçekleştirebiliyoruz. Yazar paneline gitmek için önce giriş yapmış olmanız gerekiyor. Giriş  yapmamışsanız ve 'yazar paneline git' butonuna tıklarsanız giriş yap sayfasına yönlendirileceksiniz.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/67c0e760-b990-4323-a5a1-007e8c312b32)
#### Footer Kısmı
Hakkımızda yazısındaki devamını oku butonuna tıklarsanız hakkımızda sayfasına yönlendirileceksiniz. Bize ulaşın butonu ise iletişim sayfasına yönlendiriyor. Son gönderiler ise son yayınlanan 3 bloğu dinamik olarak getiriyor.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/bfebbe39-b6f0-4a53-98fb-5b6be00f5898)


### a-) Bloglar Sayfası
Bu sayfada kullanıcılar blogları görebiliyor.Blogların devamını okuyabiliyorlar. <br/>
1/2
![BlogIndex1](https://github.com/Adilusta/CoreDemo/assets/83319176/313bf3ab-4693-4027-bd5f-ab6ac2b9ea89)
2/2
![BlogIndex2](https://github.com/Adilusta/CoreDemo/assets/83319176/bc8dbcd9-7fe7-4635-b93e-95543adffaa1)

### b-) Blog Detay Sayfası
Bu sayfada bloğun devamını okuyabilirsiniz. Sağ tarafta hangi kategoriden kaç tane blog var bunu öğrenebilirsiniz. Yine mail bültenine abone olup gelişmelerden haberdar olabilirsiniz.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/b854948b-fc43-4b17-8861-b7e2224ac9a4)

#### Bloğa yorum yapma
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/c1c3ac36-e573-4a65-a7be-33c4a9a41698)

### c-)Hakkımızda Sayfası:
Bu sayfada benim hakkımda bilgi sahibi olabilirsiniz.Sayfanın sağ tarafındaki sosyal medya logolarına tıklayarak sosyal medya hesaplarıma ulaşabilirsiniz. Abone ol kısmına mail adresiniz yazarak gelişmelerden ve maillerden haberdar olabilirsiniz.
![Hakkımızda](https://github.com/Adilusta/CoreDemo/assets/83319176/cc24d9c2-752b-4bd8-8623-e71bb79bfa67)
### d-)İletişim Sayfası:
1/2
Bu sayfadan benimle iletişime geçebilmenizi sağlayacak bilgilere erişebilirsiniz.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/cad4f391-0270-4ea9-92cb-ce3bc8b08fbc)
<br/>
2/2  
Bu kısımda ad,soyad, e mail gibi bilgilerinizi girerek admine mesajlarınızı iletebilirsiniz. Admin mesajlarınızı görecektir.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/97ed8bae-b884-4f3e-90ec-fbe1478135cf)
### e-)Giriş Yapma Sayfası
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/1fbcab23-5f2d-4b21-b5c6-1543a0659f49)
### f-)Kayıt Olma Sayfası
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/b496ac1f-313a-43f7-bc1a-adb8104e21ef)
<br/>
<br/>
## 2-) YAZAR SAYFASI
### Layout
#### Header Kısmı
Bu kısımda bildirimleri,mesajları görebilir,çıkış yapıp oturumu sonlandırabilirsiniz. Ayrıca ufak bir logo bulup logo koydum(blogin).
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/63c1cf73-75e6-4745-b7e3-1a0d0ad15e17)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/4ad8288d-a097-47b8-a9e6-4cc4fac71c6b)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/0fce8752-156b-4f7f-9d66-439a9bd51853)

#### Navbar Kısmı
Bu kısımda öncelikle giriş yapan yazarın adı ve fotoğrafı geliyor. Menülerde ise profil düzenleme,blog ekleme,mesajlar çıkış yapma ve daha birçok şey bulunuyor.Aşağıda detaylı olarak gösterdim. <br/>
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/c31289a0-f992-4870-829f-3692ba9f9e51)



### a-) Dashboard 
Bu kısımda toplam sitedeki blog sayısını, kendi blog sayınızı ve toplam kategori sayılarını görebilirsiniz. Ayrıca son eklenen 10 bloğu da burda görebilirsiniz. Linq aracılığıyla bu veriler veritabanından çekildi. <br/>
1/2
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/4eeaf978-c0cb-47d1-8b21-4df0a1195c52) <br/>

Bu kısımda yazar hakkında yazısı gözüküyor ve aktif olan kategorileri görebiliyorsunuz.<br/>
2/2
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/b373c692-2d52-42ad-a6e8-163479d4b672)


### b-) Profilim Sayfası 
Bu sayfadan kullanıcı bilgilerinizi düzenleyebilirsiniz.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/761ecdf9-ffa1-47b0-b673-308dfc9c9b25)

### c-) Bloglarım Sayfası
Burdan bloglarınızı görebilir,yeni blog oluşturabilir, blogları silebilir veya düzenleyebilirsiniz. <br/>
1/4
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/b6ebf396-495c-4230-bf76-e032b2e09904)<br/>

Sil butonuna basınca böyle bir alert çıkıyor.<br/>
2/4
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/c2ef4adb-b48b-443e-899b-712305eacccb)<br/>

Düzenleme sayfası. Kategoriler dropdownlist ile geliyor ve kullanıcı seçiyor.<br/>
3/4
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/eeefb328-bde0-43a9-ada6-921d9e3f8d76)<br/>

Burdan kullanıcı yeni blog ekleyebiliyor.<br/>
4/4
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/18522e45-803e-403d-be73-c0a062d4d212)

### d-) Mesajlarım Sayfası
Burdan mesajlarınızı görebilir,mesajın detayına bakabilir veya yeni mesaj oluşturabilirsiniz.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/d04c7703-7f5e-467c-8643-04d9d9ff6d35)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/d288004d-13b9-4c2f-ab94-f557dce33925)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/dcda85a8-3206-443f-a06b-b68a31d39a71)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/1c0346da-64b0-404d-8a3f-20ece670835b)
<br/>

### e-) Bildirimler Sayfası
Bildirimleri burdan okuyabilirsiniz.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/3281f66f-5489-4133-9185-8ab9551c2723)
<br/>
<br/>

## 3-) ADMİN PANELİ
### LAYOUT <br/>
Header kısmı : Burda mesaj bildirimleri ve genel bildirimlere bakabilir ve çıkış yap butonuna tıklayarak oturumu kapatabilirsiniz.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/abea16c4-9af4-4be9-b8a4-ddf5effc0a02)

