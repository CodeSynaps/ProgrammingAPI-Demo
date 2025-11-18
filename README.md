# ProgrammingAPI-Demo

.NET Framework 4.8 ile geliştirilmiş bir Web API demo projesidir. Bu proje, **Languages** ve **Users** yönetimi için CRUD işlemlerini örneklemektedir. Amaç **öğrenme, gösterim ve demo** amaçlıdır; gerçek kullanım için optimize edilmemiştir.

## 🚀 Özellikler

- CRUD işlemleri: GET, POST, PUT, DELETE
- Web API Attribute Routing
- Global Exception Handling (`ApiExceptionAttiribute`)
- API Key ile basit authentication (`APIKeyHandler`)
- Entity Framework 6 (EDMX) ile veritabanı erişimi
- Demo veritabanı bağlantısı (`ProgrammingDbEntities`)

## 📦 Proje Yapısı

| Klasör / Dosya          | Açıklama |
|-------------------------|----------|
| App_Start               | Route, Bundle ve Web API konfigürasyonları |
| Controllers             | API endpoint'leri (`LanguagesController`, `UsersController`) |
| Attiribute              | Global Exception Filter |
| Security                | API Key ve Authorize Attribute |
| DAL                     | Veritabanı erişim sınıfları (`LanguagesDAL`, `UserDAL`) |
| Scripts / Content       | Frontend script ve CSS (bundled) |
| EDMX (Entity Data Model)| Veritabanı ORM yapısı |

## 🔧 Kullanım

1. Visual Studio ile projeyi açın.
2. EDMX üzerinden veritabanı bağlantınızı ayarlayın.
3. Projeyi çalıştırın, API endpoint’leri `http://localhost:[port]/api/[controller]` üzerinden erişilebilir.
4. API Key kullanarak `Users` endpoint’lerine erişebilirsiniz.

- Bu proje **sadece demo** amaçlıdır, güvenlik veya performans optimizasyonu içermez.


