2.g�n

AP� KATMANI
  ---DTO
  Data transfer object. bildi�in View MOdel. BU dto i�lemleri ile gelen entity verilerini kullan�c�
  gerkesinimlerine g�re sadele�tirip yollar�z.BU i�lemleri i�in mapping bize yard�m eder.
  DTO dosyas� olu�turulup i�inde Product , Category s�n�flar�na ait propertyler ve propertieslerin
  kurallar� belirlendi.Categorywithproduct & productWithCategory Dto classlar� ile category product
  navige edildi.
  ---Mapping
  Mapping klas�r� olu�turludu i�inde a�t���m�z mapProfile s�n�f� ile dto'lar�n mapping i�lemi yap�ld�.
***NUGET'ten indirilen AutoMapped.dep.�nj package'� indirildi.
  ---Controller
  Categorycontroller Controller'� olu�turuldu. api controller i�inde ICategoryService _catService & IMapper _mapper;
  nesneleri olu�turuldu.Constructor metodu ile bu nesnelere atma yap�ld�.Constructor metodunun parametresi.....
  kategorilerin hepsini ald���m�z ve tek birini �d parametresi ile ald���m�z get metodtlar� olu�turldu.

  CORE KATMANI


  DATA KATMANI

  Unitofwork class� �nceki g�n eklenmemi�ti. o eklendi. IUnitofWork Core katman�nda. Unitofwork class�
  data katman�nda olma sebebi �al��ma alan�n�n database ile direk ili�kili olmas�d�r.Unitofwork database 
  son dokunu�unu yap�ld��� yani sahiden de�i�tirldi�i yerdir.

  SERV�CE KATMANI

  Core katman�n� bu  katman ile ba�lad�k ��nk� buradaki service classlar�n�n interfaceleri �ekirdekte.
  ---CategoryService




Controller eklendi. 

	CategoriesController


	3. g�n

	Categoricontroller 'da put ve delete methodlar� yap�ld�.
	Product controller'da get post put ve delete metodlar� yap�ld�. 
	Product s�n�f�nda InnerBarcode nesnesi kullan�c�dan al�nmayan bir nesnedir. string tipinde oldu�u i�in Nullable hatas�
	d�zeltildi.