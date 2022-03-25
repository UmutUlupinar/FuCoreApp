2.gün

APÝ KATMANI
  ---DTO
  Data transfer object. bildiðin View MOdel. BU dto iþlemleri ile gelen entity verilerini kullanýcý
  gerkesinimlerine göre sadeleþtirip yollarýz.BU iþlemleri için mapping bize yardým eder.
  DTO dosyasý oluþturulup içinde Product , Category sýnýflarýna ait propertyler ve propertieslerin
  kurallarý belirlendi.Categorywithproduct & productWithCategory Dto classlarý ile category product
  navige edildi.
  ---Mapping
  Mapping klasörü oluþturludu içinde açtýðýmýz mapProfile sýnýfý ile dto'larýn mapping iþlemi yapýldý.
***NUGET'ten indirilen AutoMapped.dep.ýnj package'ý indirildi.
  ---Controller
  Categorycontroller Controller'ý oluþturuldu. api controller içinde ICategoryService _catService & IMapper _mapper;
  nesneleri oluþturuldu.Constructor metodu ile bu nesnelere atma yapýldý.Constructor metodunun parametresi.....
  kategorilerin hepsini aldýðýmýz ve tek birini ýd parametresi ile aldýðýmýz get metodtlarý oluþturldu.

  CORE KATMANI


  DATA KATMANI

  Unitofwork classý önceki gün eklenmemiþti. o eklendi. IUnitofWork Core katmanýnda. Unitofwork classý
  data katmanýnda olma sebebi çalýþma alanýnýn database ile direk iliþkili olmasýdýr.Unitofwork database 
  son dokunuþunu yapýldýðý yani sahiden deðiþtirldiði yerdir.

  SERVÝCE KATMANI

  Core katmanýný bu  katman ile baðladýk Çünkü buradaki service classlarýnýn interfaceleri çekirdekte.
  ---CategoryService




Controller eklendi. 

	CategoriesController


	3. gün

	Categoricontroller 'da put ve delete methodlarý yapýldý.
	Product controller'da get post put ve delete metodlarý yapýldý. 
	Product sýnýfýnda InnerBarcode nesnesi kullanýcýdan alýnmayan bir nesnedir. string tipinde olduðu için Nullable hatasý
	düzeltildi.