
# QTProjectTeam

**Inhaltsverzeichnis**
1. [Einleitung](#einleitung)
2. [Datenmodell und Datenbank](#datenmodell-und-datenbank)
3. [Aufgaben](#aufgaben)
   1. [Backend-System](#backend-System)
      1. [Business-Logic](#business-logik)
      2. [Unit-Tests](#unit-tests)
      3. [AspMvc-Views](#aspmvc-views)

## Einleitung

Das Projekt ***QTProjectTeam*** ist eine datenzentrierte Anwendung zur Verwaltung von Projekten und Teammitgliedern. 

Zu entwickeln ist das Backend-System mit der Datenbank-Anbindung, eine Web-Anwendung zur Verwaltung der Stammdaten der Projekte. Zusätzlich soll ein mobiler Client zum Ansehen und Bearbeiten einer Aufgabe erstellt werden.

## Datenmodell und Datenbank

Das Datenmodell für ***QTProjectTeam*** hat folgenden Aufbau:

```txt

+-------+--------+                    +-------+--------+ 
|                |                    |                | 
|     Project    + 1 -------------- N +     Member     + 
|                |                    |                | 
+-------+--------+                    +-------+--------+ 

```

### Definition von ***Author***

| Name | Type | MaxLength | Nullable |Unique|Db-Field|Access|
|------|------|-----------|----------|------|--------|------|
| Id | int |---|---|---| Yes | R |
| RowVersion | byte[] |---| No |---| Yes | R |
| Number | String | 10 | No | Yes | Yes | RW |
| Name | String | 128 | Yes | No | No | RW |
| Description | String | 1024 | No | No | Yes | RW |

### Definition von ***Member***

| Name | Type | MaxLength | Nullable |Unique|Db-Field|Access|
|------|------|-----------|----------|------|--------|------|
| Id | int |---|---|---| Yes | R |
| RowVersion | byte[] |---| No |---| Yes | R |
| ProjectId | int | --- | No | No | Yes | RW |
| Firstname | String | 64 | No | No | Yes | RW |
| Lastname | String | 64 | No | No | Yes | RW |
| Note | String | 2048 | No | No | Yes | RW |

## Aufgaben  

### Backend-System  

Erstellen Sie das Backend-System mit der Vorlage ***QuickTemplate*** und definieren die folgenden ***Komponenten***:

- Erstellen der ***Enumeration***
  - *keine*
- Erstellen der ***Entitäten***
  - *Project*
  - *Member*
- Definition des ***Datenbank-Kontext***
  - *DbSet&lt;Project&gt;* definieren
  - *DbSet&lt;Member&gt;* definieren
  - partielle Methode ***GetDbSet<E>()*** implementieren
- Erstellen der ***Kontroller*** im *Logic* Projekt
  - ***ProjectsController***
  - ***MembersController***
- Erstellen der ***Datenbank*** mit den Kommandos in der ***Package Manager Console***
  - *add-migration InitDb*
  - *update-database*
- Implementierung der ***Business-Logic***
  - Überprüfen der Geschäftslogik mit ***UnitTests***
- Importieren von Daten (optional)

#### Business-Logik  

Das System muss einige Geschäftsregeln umsetzen. Diese Regeln werden im Backend implementiert und müssen mit UnitTests überprüft werden. 

> **HINWEIS:** Unter **Geschäftsregeln** (Business-Rules) versteht man **elementare technische Sachverhalte** im Zusammenhang mit Computerprogrammen. Mit *WENN* *DANN* Scenarien werden die einzelnen Regeln beschrieben.  

Für das ***ProjectTeam*** sind folgende Regeln definiert:

| Rule | Subject | Type | Operation | Description | Note |
|------|---------|------|-----------|-------------|------|
|**A1**| Project |  |  |  |  |
|  |  |*WENN*|  | ein Projekt erstellt oder bearbeitet wird, |  |
|  |  |*DANN*|  | muss die Nummer gültig sein |  |
|  |  |      | UND | die Nummer muss eindeutig sein. |  |
|**B1**| Member |  |  |  |  |
|  |  |*WENN*|  | ein Mitglied erstellt oder bearbeitet wird, |  |
|  |  |*DANN*|  | muss ein Projekt zugeordnet sein. |  |
|  |  |      | UND | der Vorname (mind. 3 Zeichen) definiert sein |  |
|  |  |      | UND | der Nachname (mind. 3 Zeichen) definiert sein. |  |

**Prüfung der Projekt-Nummer**

Die Prüfziffer (zehnte Ziffer) der Nummer berechnet sich wie folgt:  
Man multipliziere die erste Ziffer mit eins, die zweite mit zwei, die dritte mit drei und so fort bis zur neunten Ziffer, die mit neun multipliziert wird.  
Man addiere die Produkte und teile die Summe ganzzahlig mit Rest durch 11. Der Divisionsrest ist die Prüfziffer.  
Falls der Rest 10 beträgt, ist die Prüfziffer ein "X".  
1. Beispiel: Projekt-Nummer 3-499-13599-[?]
3·1 + 4·2 + 9·3 + 9·4 + 1·5 + 3·6 + 5·7 + 9·8 + 9·9 = 3 + 8 + 27 + 36 + 5 + 18 + 35 + 72 + 81 = 285
285:11 = 25 Rest 10 ⇒ Prüfziffer: X
2. Beispiel: Projekt-Nummer 3-446-19313-[?]
3·1 + 4·2 + 4·3 + 6·4 + 1·5 + 9·6 + 3·7 + 1·8 + 3·9 = 3 + 8 + 12 + 24 + 5 + 54 + 21 + 8 + 27 = 162
162:11 = 14 Rest 8 ⇒ Prüfziffer: 8
3. Beispiel: Projekt-Nummer 0-7475-5100-[?]
0·1 + 7·2 + 4·3 + 7·4 + 5·5 + 5·6 + 1·7 + 0·8 + 0·9 = 14 + 12 + 28 + 25 + 30 + 7 = 116
116:11 = 10 Rest 6 ⇒ Prüfziffer: 6
4. Beispiel: Projekt-Nummer 1-57231-422-[?]
1·1 + 5·2 + 7·3 + 2·4 + 3·5 + 1·6 + 4·7 + 2·8 + 2·9 = 1 + 10 + 21 + 8 + 15 + 6 + 28 + 16 + 18 = 123
23:11 = 11 Rest 2 ⇒ Prüfziffer: 2  

Wenn die Projekt-Nummer nicht stimmt (ungültige Prüfziffer), dann wird eine Ausnahme geworfen.

#### Unit-Tests  

All diese Geschäftsregeln müssen mit **UnitTests** überprüft werden. Fügen Sie dazu zur Lösung (Solution) ein Projekt mit dem Namen ***'QTProjectTeam.Logic.UnitTest'*** hinzu und implementieren Sie die Tests.
 
### AspMvc-Views  

Erstellen Sie für die folgenden Entitäten Ansichten im AspMvc-Projekt:

> Der Kontroller ***AuthorsContoller*** ist bereits erstellt.

- Projekt 
  - ListView - Übersicht der Projekte
  - Create - Erstellen eines Projektes
  - Edit - Bearbeiten eines Projektes
  - Delete - Löschen eines Projektes mit Rückfrage

> Erstellen Sie den ***ProjectsController*** nach dem gleichem Schema von ***MembersController***.
   
- Member 
  - ListView - Übersicht der Mitglieder
  - Create - Erstellen eines Mitgliedes mit Zuordnung Projekt (DropDownList)
  - Edit - Bearbeiten eines Mitgliedes mit Zuordnung Projekt (DropDownList)
  - Delete - Löschen eines Projektes mit Rückfrage

> **HINWEIS:**  Ausnahmen und Fehler müssen dem Benutzer entsprechend angezeigt werden.

**Viel Spaß beim Umsetzen der Aufgabe!**
