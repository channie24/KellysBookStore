서점관리 프로그램을 KellysBookStore라는 이름으로 만들어보았습니다.
아래와 같은 순서로 테스트 권장드립니다.
0. 임의의 책 생성 -> 3. 등록된 책 목록 확인 -> 1.  책 등록 ->3. 등록된 책 목록 확인 -> 4 -> 5-> 6 -> 7 -> 8


콘솔프로그램을 실행시 아래와 같은 항목들이 출력됩니다.

0. Create Books
 : 제가 임의로 작성해 둔 책 목록이 Add됩니다. 

1. Search Google Books related C#
 : google books api에서 "C# Programming"이라는 키워드를 포함한 책의 목록을 가져옵니다.

2. Add Book 
 : 한권의 책을 등록할 수 있습니다. (제목/ 저자/등록일)

3. List Books
 : 등록되어있는 책들이 출력됩니다.

4. Search Books 
 : 입력한 키워드로 책의 제목과 저자를 검색해서 출력합니다.

5. Generate Sales Data 
 : 12개월간의 판매내용을 임의로 등록합니다.

6. Analyze Sales Data
 : 책별 총 수익, Best Seller, 12개월 중 총 판매량이 가장 많은 달을 출력합니다. 

7. Export Data 
 : 책과 판매내역을 json 파일로 생성

8. Import Data
 : json 파일에서 책과 판매내역을 생성 

9. Exit
 : 종료
