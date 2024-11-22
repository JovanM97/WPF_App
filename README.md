# WPF_App

Specifikacija projekta

Graf mreže je potrebno iscrtati na osnovu sadržaja datoteke Geographic.xml (data u okviru materijala za prvi termin vežbi), dok sam graf aproksimira mrežu na ortogonalni prikaz. Prvo je potrebno da se površina za iscrtavanje podeli na (“zamišljene”) podeoke, a što je više takvih podeoka definisano, to će prikaz biti detaljniji. Potom se učitavaju koordinate iz xml fajla i crtaju se entiteti mreže, tako što se aproksimiraju na najbliži podeok na površini za crtanje.

Entiteti mreže se iscrtavaju tako što se iscrtava slika (grafički element) koja će predstavljati datu vrstu entiteta (Substation, Node ili Switch). Za svaki grafički element se prikazuje ToolTip sa informacijom koji entitet se tu nalazi. Entiteti mreže se aproksimiraju na najbliži slobodni podeok, bez preklapanja. U ovom slučaju treba voditi računa o minimalnom broju podeoka kako bi bilo prostora da se prikažu svi entiteti. 

Vodovi, koji spajaju entitete, se crtaju kao prave linije i ukoliko je potrebno, linija mora da skreće samo pod pravim uglom. Posmatraju se samo Start i End Nodes u linijama, a Vertices se ignorišu. 
Iscrtavaju se samo one linije čiji Start i End Node postoje u kolekcijama entiteta. Ostali vodovi se ignorišu. Treba ignorisati ponovno iscrtavanje vodova izmedju dva ista entiteta. Linija uvek mora da kreće iz centra entiteta, ne iz gornjeg levog ugla (pozicije iscrtavanja) entiteta. 

Nalazi se najkraći mogući put BEZ presecanja sa već postojećim iscrtanim vodovima (kroz upotrebu BFS algoritma). U drugom prolazu se iscrtavaju vodovi za koje u prvom prolazu nije bilo moguće naći put bez presecanja i tada se oni iscrtavaju uz označavanje tačaka preseka. 
Predlog: Algoritam započeti od neka dva entiteta koja imaju najmanju udaljenost u mreži. 

Desnim klikom na vod koji spaja dva entiteta se pokreće animacija koja traje jednu sekundu i u kojoj se grafički elementi koji prikazuju entitete uvećavaju dva puta i menjaju boju, tako da je ona različita od ostalih, kako bi korisnik znao koji elementi su povezani tim vodom. Elementi ostaju obojeni različitiom bojom dok se ne klikne na drugu liniju. 

Potrebno je omogućiti zumiranje prikaza mreže tako da se pomoću skrol-barova može pomerati pogled nad zumiranom delu mreže, kao i da se prikaz mreže može „odzumirati“. 

Na vrhu prozora, potrebno je ponuditi korisniku opcije da se iscrtani graf mreže može dopunitioblicima i/ili tekstom:
- a. Draw Ellipse: izborom ove opcije, potom klikom na desni taster miša na površini Canvas-a otvara se novi prozor u okviru kojeg se unose i biraju atributi elipse (dužine poluprečnika, debljina konturne linije, boje) posle čega se iscrtava elipsa po zadatim atributima. Takođe, opciono ponuditi korisniku da unese tekst koji će biti napisan na površini iscrtane elipse i izbor boje teksta (veličina teksta je fiksirana). 
- b. Draw Polygon: izborom ove opcije, potom klikom na desni taster miša na Canvas određuju se tačke koje će ograničiti površinu poligona. Kada se sve tačke odrede, levim klikom na površini Canvas-a otvara se novi prozor u okviru kojeg se unose i biraju atributi poligona (debljina konturne linije, boje) posle čega se iscrtava poligon po zadatim atributima. Takođe, opciono ponuditi korisniku da unese tekst koji će biti napisan na površini iscrtanog poligona i izbor boje teksta (veličina teksta je fiksirana). 
- c. Add Text: izborom ove opcije, potom klikom na desni taster miša na površini Canvas-a otvara se novi prozor u okviru kojeg se unose i biraju atributi teksta: sam tekst, njegova boja i veličina. 
- d. Undo: poništava iscrtavanje oblika ili teksta (nakon Clear vraća sve što je obrisano) 
- e. Redo: vraća prethodno uklonjen oblik ili tekst 
- f. Clear: prazni Canvas od svih iscrtanih oblika ili teksta 

Kao dodatne opcije vizuelizacije mreže u aplikaciji, potrebno je: 
- entitete (osim vodova) crtati različitim intenzitetom boje na osnovu broja konekcija: od 0 do 3 konekcije - svetlo crvena; od 3 do 5 - crvena; više od 5 - intenzivno crvena. 
- ako je vod podzeman (svojstvo IsUnderground = true) crtati ga crnom bojom. Ostale vodove crtati različitim bojama u zavisnosti od materijala od kojeg je vod konstruisan. 
- omogućiti promenu boje vodova na osnovu otpornosti: ispod 1 - crvena boja; od 1 do 2 - narandžasta; iznad 2 - žuta boja, ali i da se boja može vratiti na inicijalnu. 
- omogućiti promenu boja entiteta tipa Switch čiji je status „Open“ i vodova koji izlaze iz njih u crvenu boju, a entiteta tipa Switch čiji je status „Closed“ i vodova koji izlaze iz njih u plavu boju. Ostali elementi se sakrivaju. 
- omogućiti promenu boja grafičkih elemenata koji služe kao prikaz entiteta u mreži (da to može biti i slika), ali i da se boja može vratiti na inicijalnu – ovo treba da radi tako da se prilikom izbora boje, ona primeni na već iscrtanoj mreži ili da se odredi pre samog iscrtavanja. Ovako izabrana boja/slika se primenjuje na celu grupu istih elemenata (Substation, Node ili Switch) na već iscrtanom grafu. 
- dodati mogućnost da se promene parametri animacije: boja u koju se boje entiteti, koliko puta se uvećavaju, kao i koliko traje animacija. 
- sačuvati trenutni prikaz u Canvas-u kao sliku, tako da ime fajla sadrži vremenski trenutak kada je slika sačuvana 

Napomene: 
- Tooltip-ovi prikazuju ID i ime entiteta, a prikazuju se i za veze (vodove). 
- Svi oblici (i tekst) se iscrtavaju tako da im je gornji levi ugao pozicija gde je pokazivačem miša kliknuto da bi se inicirala akcija crtanja. Kada se kaže “na površinu Canvas-a” tu se misli i na prethodno nacrtane oblike i tekst (mogu se iscrtavati jedni preko drugih). 
- Svaki od iscrtanih oblika i tekst treba da ima opciju da se klikom levim tasterom miša na njega mogu menjati njegovi atributi izgleda (boje i debljine konturna linije, a za tekst njegova boja i veličina). 
- Prilikom bojenja oblika koji se iscrtavaju preko mreže, ponuditi opciju da se izabranoj boji može dati efekat providnosti.
