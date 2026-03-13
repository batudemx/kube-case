.NET API Deployment on Kubernetes
Bu proje, bir .NET 9.0 uygulamasının konteynerize edilmesi ve Kubernetes (K8s) üzerinde yüksek erişilebilirlik  ve kendi kendini iyileştirme (self-healing) özellikleriyle canlıya alınmasını içeren bir Case Study çalışmasıdır.

Kullanılan Teknolojiler
Backend: .NET 9.0 Minimal API

Konteynerizasyon: Docker (Multi-stage build)

Orkestrasyon: Kubernetes (K8s)

Registry: Docker Hub

Proje Gereksinimleri 
1. API Geliştirme
GET /: {"msg":"BC4M"} cevabını döner.

GET /health: Liveness Probe için uygulamanın sağlık durumunu bildirir.

POST /: Gönderilen body verisini geri yansıtır (Reflect).

2. Dockerizasyon
Uygulamanın image haline getirilmesinde dockerfile'da multi-stage-build kullanılarak image boyutu minimal seviyeye getirilmiştir.

Runtime: Sadece gerekli olan runtime imajı kullanılarak güvenlik ve performans artırılmıştır.

3. Kubernetes Yapılandırması
Deployment: Uygulama da iki adet replica pod bulunmaktadır. iki pod sürekli olarak ayaktadır. Podların çökmesi kapatılması durumunda deployment controller aracı mevcut durum ile istenilen durum kıyaslaması yapark anlık olarak çöken,kapatılan pod'dan tekrar oluşturacaktır

Self-Healing: Liveness Probe sayesinde /health endpoint'i düzenli kontrol edilir; uygulama donarsa K8s konteynerı otomatik olarak yeniden başlatır.

Service: LoadBalancer tipi kullanılarak uygulama dış dünyaya (Port 80) açılmıştır.

Kurulum ve Çalıştırma
Docker ile Çalıştırma

# İmajı build et
docker build -t batudemx/b4cm-api:latest .

# Konteynerı çalıştır
docker run -d -p 5000:5000 --name bc4m-api batudemx/b4cm-api:v1
Kubernetes (kubectl) ile Dağıtım
Bash
# Yapılandırmayı cluster'a uygula
kubectl apply -f deployment.yaml

# Durumu kontrol et
kubectl get pods
kubectl get service bc4m-api-service

Geliştirme ekran görüntülüleri :


<img width="706" height="183" alt="Ekran görüntüsü 2026-03-13 141555" src="https://github.com/user-attachments/assets/583fa06f-1f9a-4bf9-b57b-91445aec8903" />

<img width="1814" height="768" alt="Ekran görüntüsü 2026-03-13 141530" src="https://github.com/user-attachments/assets/5e564333-e9f2-47f2-ab9c-c2481ff14b49" />


