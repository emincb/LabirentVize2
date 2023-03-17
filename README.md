# LabirentVize2
Emin Can BAŞKAYA
2.Vize Proje Ödevi- Labirent Üretme,Çözme
1030510600
Erciyes Universitesi Bilgisayar Muhendisligi 1.Sınıf


I applied the maze-solving algorithm with the recursive backtracking method for this assignment.

When the start button is pressed, my code creates a maze and saves it to a .txt file on the desktop, and presents a menu in front of us. This menu asks us to choose one of the options to show the original maze, solve the maze, or show the coordinates of the bombs in the maze with B letters. The options can be selected in order with the letters L, X, B.

In my maze-solving algorithm, entry and exit points in the maze can be manually adjusted, and it will still try to find the solution even if it is not adjusted manually. The algorithm I created using recursive backtracking to solve the maze works simply as follows:

Step 1: If the current point is the destination, return successful.
Step 2: Or if the current point is a dead end, return unsuccessful.
Step 3: And if the current point is not a dead end, continue to explore the maze by repeating the above steps.

While applying the above steps, I also check whether a bomb has been encountered, whether any exit has been reached, and whether the current coordinates are within the boundaries of the maze. If a bomb is encountered, a beep sound is made and the path taken until the bomb is encountered is drawn in 1s and 0s. If it reaches any of the exits, it prints the x and y coordinates that lead to the exit and then shows the path taken in 1s and 0s to the exit on the maze.

Nested for loops are used for file printing and reading methods. When creating the maze, I create the maze using logical operators, neighbor walls, whether the path has been taken before, wall remover, path goer, and cell state methods, and then print it to a .txt file using FileStream.

The mazeCöz class in my code contains everything necessary to solve the maze. This algorithm works as follows:

After determining the starting points or trying to find the entrance and exit points in the code with bool functions, it first checks whether there is a bomb with an if statement.
It checks whether it has reached the row where the exit is located with an if loop, and if it has, it marks the corresponding point in the solution matrix and returns true.
Then it enters the function where the actual recursive backtracking takes place, and checks this with the sinirdaMi function.
If it is at the boundary, it checks whether x and y are included in the current solution matrix, and if so, returns false.
Then it marks the found point as coz[x, y] = 1 and calls the function itself by incrementing and decrementing the x and y directions step by step, and returns true if it is correct.
If none of the above works and it does not enter the loop, it marks coz[x, y] = 0 and returns false.



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
 
 
