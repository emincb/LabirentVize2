# LabirentVize2
Emin Can BAŞKAYA
2.Vize Proje Ödevi- Labirent Üretme,Çözme
1030510600
Erciyes Universitesi Bilgisayar Muhendisligi 1.Sınıf



      Bu ödev için labirent çözme algoritmasını recursive backtracking metoduyla uyguladım.
      
   Kodum başlat tuşuna basıldığı anda bir labirent oluşturup masaüstündeki bir .txt dosyasına kaydediyor ve önümüze bir menü getiriyor. Bu menüde orijinal labirent gösterme,labirent çözme ve labirentteki bombaları B harfleriyle olduğu koordinatları labirent üzerinde 	gösteren seçeneklerden birini seçmemizi istiyor.Seçenekler
sırasıyla L,X,B harfleri ile seçilebilir.

	Labirent çözme algoritmamdaki labirente giriş ve çıkış noktaları el ile ayarlanabilir durumda ayrıca el ile ayarlanmadığı zaman yine de çözümü  bulmayı deneyecektir.
	Labirent çözmek için oluşturduğum recursive backtracking kullanan algoritma basitçe şu şekilde işliyor.
	Adım 1 Eğer şuanki bulunan nokta hedef ise 
					başarılı olduğunu döndür
	Adım 2 veya şuanki bulunan nokta çıkmaz nokta ise
					başarısız döndür
  Adım 3 Ve eğer şuanki nokta çıkmaz nokta değil ise
				yukarıdaki adımları tekrar ederek labirenti gezmeye devam et
		
 Yukarıda belirttiğim adımları uygularken aynı zamanda bombayla karşılaşıldı mı,herhangi bir çıkışa ulaşıldı mı ve şuan bulunduğumuz koordinatlar labirent sınırları içerisinde mi diye kontrol eder.
 Eğer bombayla karşılaşır ise bip sesi çıkarır ve bombayla karşılaşana kadar gelinen yolu 1 ve 0 lar ile çizer.
 Eğer çıkışlardan herhangi birine ulaşırsa çıkışa ulaştıran x,y koordinatlarını yazdırır ve daha sonra 1 ve 0 lar halinde çıkışa giden yolu labirent üzerinde gösterir.
 
 Dosya yazdırma ve okuma yöntemleri için iç içe for döngüleri kullanır.
 Labirent oluştururken ise oluşturduğum algoritma mantık operatörleri yardımıyla komşu duvarları , yolun daha önce gidilip gidilmediğini , duvar kaldırıcı , yol gidici ve hucre durumu metodlarını kullanarak labirenti oluşturur ve FileStream yardımıyla .txt dosyasına yazdırır.
 
 Kodumdaki labirentCöz classı labirentin çözülmesi için gerekli her şeyi bulunduruyor.Bu algoritma şu şekilde işliyor : 
 1.Başlangıç noktalarını belirledikten sonra veya giriş ve çıkış noktalarını koda buldurmaya çalışarak başlattığımızda bool fonksiyonlar yardımıyla önce if ile bomba olup olmadığını kontroll eder.
 2.Çıkışın bulunduğu satıra kadar gelebilmiş mi if döngüsü ile kontrol eder eğer gelmiş ise çözüm matrisindeki karşılık gelen noktayı işaretler ve true döndürür.
 3.Daha sonra asıl recursive backtracking algoritmasının gerçekleştiği fonksiyona girer ve sinirdaMi fonksiyonuyla bunu kontrol eder.
 4.Eğer sınırda ise x ve y nin şuanki cözüm matrisine dahil olup olmadığını kontrol eder ve öyle ise false döndürür.
 5.Daha sonra bulunan noktayı coz[x,y] = 1 olarak işaretler ve x , y yönlerinde teker teker adımlar atarak bulunduğu fonksiyonun kendisini x ve y değerlerini arttırıp azaltarak çağırır ve doğruysa true döndürür.
 6.Eğer yukarıdakilerden hiçbiri çözüm vermezse ve döngüye girmezse coz[x,y] = 0 olarak işaretler ve false döndürür.
 
 
