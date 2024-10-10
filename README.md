**Proje Adı: API Pool**  

**Geliştirme Amacı ve Kapsam:**  
API Pool çözümünü, .NET 8.0 teknolojisi ile eğitim ve öğrenme amacıyla geliştirdim. Bu proje, çeşitli veri kaynaklarından bilgi çekebilen ve bu verileri farklı amaçlarla kullanılabilir hale getiren bir API koleksiyonudur. Proje kapsamında **SqlServerAPI**, **EarthquakesAPI** ve **TCMBTodatAPI** olmak üzere üç ana API geliştirdim. Her biri belirli veri kaynaklarına odaklanarak çeşitli veri setleriyle işlem yapmayı ve kullanıcıya anlamlı sonuçlar sunmayı amaçlıyor. 

1. **SqlServerAPI**: Bu API, SQL Server veritabanına erişim sağlamak için tasarlandı. Bir veritabanı sunucusuna bağlanarak, veri sorgulama, verileri listeleme, ekleme, güncelleme ve silme işlemlerini gerçekleştirebiliyor. Özellikle veritabanı işlemlerini merkezileştirerek daha geniş sistemlerde kullanılabilecek esnek ve ölçeklenebilir bir yapı sağlamak üzere geliştirildi.

2. **EarthquakesAPI**: Bu API, özellikle depremlerle ilgili veri sağlayan bir çözüm sunar. Deprem verilerini kamuya açık kaynaklardan çekerek kullanıcıya tarih, zaman, büyüklük, yer ve derinlik gibi bilgileri sunar. Ayrıca, belirli tarihler arasında gerçekleşmiş depremleri listeleyebilme ve kapsamlı analiz yapabilme özelliği ile deprem verilerinin analiz edilmesine yardımcı olur.

3. **TCMBTodatAPI**: Bu API, Türkiye Cumhuriyet Merkez Bankası'nın günlük döviz kuru verilerini sağlamaya yönelik olarak tasarlandı. Döviz verilerini gerçek zamanlı olarak güncelleyip, kullanıcılara güncel döviz kuru, geçmiş döviz kurları gibi bilgileri sunar. Finansal uygulamalarda kullanılabilecek, döviz kuru bazlı analizlerde bilgi sağlamak için idealdir.

**Katmanlı Mimari:**  
Proje, **Utility**, **Core**, **Data** ve **Business** olmak üzere dört ana katman üzerine inşa edildi:

- **Utility Katmanı**: Ortak fonksiyonlar, genel yardımcı sınıflar ve projede sıkça kullanılan araçlar bu katmanda yer almaktadır. Bu, diğer katmanların tekrar eden işlevleri yeniden yazmak yerine burada tanımlanan fonksiyonları kullanarak zamandan ve çabadan tasarruf etmesini sağlar.
  
- **Core Katmanı**: Uygulamanın ana çekirdeğini oluşturan arayüzler, temel sınıflar ve uygulamanın tüm API’leri tarafından kullanılacak genel yapı taşları Core katmanında bulunur. Özellikle dependency injection yapılandırmaları, model ve DTO sınıfları burada yer alır.

- **Data Katmanı**: Bu katman, veritabanı işlemlerini gerçekleştirmek üzere Entity Framework gibi ORM araçlarını içerir. Veritabanı sorguları, ilişkisel veri modelleri ve veritabanı bağlantıları burada tanımlanır. Ayrıca, verilerin depolanması ve yönetilmesinden sorumludur.

- **Business Katmanı**: İş mantığının tanımlandığı bu katman, kullanıcıdan gelen isteklerin nasıl işleneceğine dair kuralları barındırır. Bu sayede, her bir API'nin kendine özgü iş mantığını soyutlayarak daha yönetilebilir ve anlaşılabilir bir yapı sağlar.

**Dependency Injection (IOC) Uygulaması:**  
Projemde **Inversion of Control (IOC)** tekniğini kullanarak bağımlılıkları yönetilebilir hale getirdim. Bu sayede, uygulamanın farklı bileşenlerinin birbiriyle olan bağımlılığını minimum seviyede tutarak daha esnek ve genişletilebilir bir yapı elde ettim. IOC tekniği, özellikle test aşamasında fayda sağlayarak uygulamanın test edilebilirliğini artırdı.

**Öğrenim ve Gelişim:**  
Bu proje, sadece API geliştirmeyi değil aynı zamanda **katmanlı mimari, dependency injection, modüler yapı oluşturma** gibi yazılım geliştirme ilkelerini de uygulamalı olarak öğrenme fırsatı sundu. API Pool çözümü, gerek veri kaynaklarının entegrasyonu gerekse de işlevsellik açısından modüler ve yeniden kullanılabilir bir çözüm sunmaktadır. İlerleyen aşamalarda projeye yeni API'ler ekleyerek genişletilebilir bir yapı kurmayı ve böylece daha kapsamlı bir veri havuzu oluşturmayı hedefliyorum.
