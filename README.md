# CoreDemo
Bu proje Murat Yücedağ ile ASP. Net Core 5.0 kampında geliştirilmiştir. Proje; kullanıcı,yazar ve admin panelli bir blog sitesidir.
Projeyi geliştirirken kullandığım bazı yapılar ve teknolojiler şöyle : 
ASP .NET Core 5.0 ile Entity Framework Core, N-Tier Architecture Mimari yapısına uygun olarak, Repository Design Pattern, LINQ , Fluent Validation Core, Statik ve Dinamik  Raporlama, Code First yaklaşımı, Web API , Asp .Net Core Identity , JWT, Google Chart, Swagger ve Postman ile API Testi,JWT, Dashboard, Api Consume, View Components, Rolleme, Yetkilendirme, Authentication, Authorize, Session Yönetimi, Ajax, Pagination,Backend olarak C# programlama dili, veri tabanı olarak SQL Server, Frontend arayüz tasarımında Html-CSS-Bootstrap kullanılarak Visual Studio 2022 editöründe Kullanıcı, Yazar ve Admin panelli bir blog sitesi geliştirilmiştir.

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
<br/>
Navbar kısmı: <br/>
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/79255804-a9da-437e-a39b-a7258ce4db18)

### a-) Dashboard <br/>
Bu kısımda weather api  ile İstanbul'un anlık hava durumu güncel olarak çekiliyor. Linq sorguları ile toplam blog sayısı,toplam yorum sayısı,son eklenen blog gibi bilgiler çekilmektedir. Bunun dışında iletişim bilgileri ve diğer bilgiler de yer almaktadır. 
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/ae28e6a3-f616-45e8-852d-50d564436e5a)
<br/>
### b-) Grafikler <br/>
Bu kısımda kategorileri grafik olarak görüyoruz.
![grafik](https://github.com/Adilusta/CoreDemo/assets/83319176/00988c20-b7d8-41c6-9774-1b415a87b3f9)
<br/>
### c-) Mesajlar <br/>
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/f84b8e84-2e03-4a37-9cfb-1297bbe2a672)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/2a586f96-402e-48d2-a0d4-16300cf836aa)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/aaa90af2-7fc3-4d80-b843-2900f94ca8f5)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/376874b0-5c2b-4b9d-b4fc-bb50949a3469)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/33806aa7-dcf6-4fe4-8cb0-f2b74db319e8)


<br/>

### d-) Kategoriler <br/>

Kategorileri görüp ekleme,düzenleme,silme işlemleri yapabiliyoruz.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/758ac45c-635e-4674-af7c-aa9737f93384)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/191e3d85-7b84-487f-a8bb-2fd1b269ae61)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/10518c61-9e50-4670-9262-34ca7554c785)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/8ffc2e66-46c2-4ca4-b33a-be0e00927386)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/386fbd71-4326-40c7-a03b-f63aa1d869dc)

### e-) Bloglar <br/>
Tüm blogları burdan görebiliyoruz.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/df296ebf-2541-451c-afb5-bf9af57ee017)

### f-) Yorumlar <br/>
Buradan tüm yorumları görebilir,silebilir veya düzenleyebiliriz.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/219ad1e4-cae6-42c9-bf75-708ac7fe3020)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/47632ba9-c611-4963-b392-8d279ba76a2b)

### g-) Roller <br/>
Bu kısımdan rolleri görüp, yeni rol ekleyip silebiliriz ayrıca hangi kullanıcıya hangi rolü atayacağımızı seçebiliriz.
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/a6965c35-1baa-4fbb-b8d2-5be17b61c785)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/e2e47434-56ff-47d4-8bb6-4223f3548143)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/d06b84f9-edbf-421c-97ff-59315bfee19d)
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/351fd8e3-ca4b-4d7f-a606-6f52023785e4) <br/>
Rol Ata kısmına basıp bu şekilde kullanıcının rollerini güncelleyebiliriz.<br/>
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/84fa4202-624a-4679-a177-a19f2de9ae98)

### h-) Blog Raporu İndirme <br/>
Bu butona tıklayarak blogları excel dosyası olarak indirebilirsiniz. <br/>
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/3827fbc3-9177-43ff-aa35-9c6b8b753717) <br/>
Bu şekilde excel tablosu olarak indirip inceleyebilirsiniz. <br/>
![image](https://github.com/Adilusta/CoreDemo/assets/83319176/c298fe2f-f968-4dec-8b99-6a4a1ecbc19e)

