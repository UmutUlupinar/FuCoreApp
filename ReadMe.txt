N-TIER PROJECT
()

APİ KATMANI
  ---DTO
  Data transfer object. bildiğin View MOdel. BU dto işlemleri ile gelen entity verilerini kullanıcı
  gerkesinimlerine göre sadeleştirip yollarız.BU işlemleri için mapping bize yardım eder.
  DTO dosyası oluşturulup içinde Product , Category sınıflarına ait propertyler ve propertieslerin
  kuralları belirlendi.Categorywithproduct & productWithCategory Dto classları ile category product
  navige edildi.
  ---Mapping
  Mapping klasörü oluşturludu içinde açtığımız mapProfile sınıfı ile dto'ların mapping işlemi yapıldı.
***NUGET'ten indirilen AutoMapped.dep.ınj package'ı indirildi.
  ---Controller
  Categorycontroller Controller'ı oluşturuldu. api controller içinde ICategoryService _catService & IMapper _mapper;
  nesneleri oluşturuldu.Constructor metodu ile bu nesnelere atma yapıldı.Constructor metodunun parametresi.....
  kategorilerin hepsini aldığımız ve tek birini ıd parametresi ile aldığımız get metodtları oluşturldu.

  CORE KATMANI


  DATA KATMANI

  Unitofwork classı önceki gün eklenmemişti. o eklendi. IUnitofWork Core katmanında. Unitofwork classı
  data katmanında olma sebebi çalışma alanının database ile direk ilişkili olmasıdır.Unitofwork database 
  son dokunuşunu yapıldığı yani sahiden değiştirldiği yerdir.

  SERVİCE KATMANI

  Core katmanını bu  katman ile bağladık Çünkü buradaki service classlarının interfaceleri çekirdekte.
  ---CategoryService




Controller eklendi. 

	CategoriesController




	Categoricontroller 'da put ve delete methodları yapıldı.
	Product controller'da get post put ve delete metodları yapıldı. 
	Product sınıfında InnerBarcode nesnesi kullanıcıdan alınmayan bir nesnedir. string tipinde olduğu için Nullable hatası
	düzeltildi.
