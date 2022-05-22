N-TIER PROJECT
()

API;

 MVC katmannı yani arayüzümüz apiden gelecek datayı kullanacaktır.
DTOs sınıfları ile kullanıcıya gösterilecek verileri tutacaktır.
Filters sınıfları ile kullanıcıya filtreyle errorları tutacaktır.
Extensions ile hataları sadece koduyla değil spesifik şekilde kullanıcya ulaştırır.
MapProfile ile classlar ile dto'ları arasındaki mapi sağlar.

Api/Controllers

 Service katmanından gelecek ve mappingden gelecek nesneler DI ile inject edilir.Service içindeki
metotların döndürdüğü değer dto'ya sokulur ve kullanıcıya hazır vaziyette döndürülür.
Mesela kullanıcıdan gelecek verileri ise tekrar tersine map ile dto'dan çıkarılır ve service katmanından 
geçirilir. Sonuç datası elde edilir ve Dto'ya sokulur ve kullaıcıya hazır vaziyette döndürülür.

Api/program.cs

 İş katmanlarındaki (Repository ve Service) classların interfaceleri ile bağlantı için addscoped kullanılır.
Mapper içinde automapper metodu kullanılır.

CORE;

Model ve Interface'leri içerir. İşin çekirdeğidir. :Shared'de denebilir.

DATA;

 Database ilişkisi burada kurulur. Seed data eklenir, tablolar konfigure edilir.Repository'ler burada 
oluşturulur.Çünkü database ile dolaysız ilişki içindedirler.Unitofwork database son dokunuşunu yapıldığı 
yani sahiden değiştirldiği yerdir.Unitofwork classı data katmanında olma sebebi çalışma alanının database
ile direk ilişkili olmasıdır. UnitofWork ve Repository database ile işlem yapan claslarımızdır.
Seed ve Configuration sınıflarımız ise code first ile olşturlan tablolar için konfigüreler ve default 
datalar içerir.
Bu classlardaki işlemlerin hepsini DbContext'ten kalıtım alan AppDbContext sınıfımızda da yapabilinir
fakat bu şekilde tüm diyagram solid'e uygun olmakla beraber database kısmına müdahale kolaylığı sağlar.


  SERVİCE KATMANI

  Core katmanını bu  katman ile bağladık Çünkü buradaki service classlarının interfaceleri çekirdekte.
  ---CategoryService
