yung parts ng code na ito po medyo nahirapan talaga ako gawin mag-isa kaya gumamit po ako ng AI para makatulong intindihin yung logic at kung paano dapat gumana yung system. 
nung una po kasi, hindi ko maayos mapagana yung cart at stock na part kaya dito ako nagpatulong para mas maintindihan ko yung flow.

dun po sa system, gumagamit siya ng arrays para mag-store ng cart items tulad ng product ID, quantity, at subtotal.
Medyo challenging po para sakin kasi manual yung pag-manage ng data gamit index, kaya kailangan careful lagi para hindi magkamali yung matching ng data, 
kasi isang mali lang po sa index, nagkakagulo na yung laman ng cart.

yung unang problem po na na-encounter ko is yung pag-check ng stock.
dito chine-check kung sapat pa ba yung available stock bago payagan yung purchase. 
Kapag mas mataas yung quantity kaysa stock, hihinto yung process at lalabas po yung message na kulang ang stock. 
dito po ako nahirapan kasi hindi lumalabas ng tama yung error message at minsan napo-proceed pa rin yung order kahit kulang na yung stock.

next is yung “already in cart” logic. Dito chine-check kung yung item na pinili ng user ay existing na sa cart. 
Ginagawa ito sa pamamagitan ng loop na nagco-compare ng product ID. Kapag nakita na yung item, 
hindi na siya magdadagdag ng duplicate, instead dinadagdagan na lang yung quantity at ina-update yung subtotal. 
Medyo tricky po itong part kaya naguluhan ako dati kung bakit dumadami yung same item kaya dito ako humingi ng help sa AI para mas malinaw yung flow.

kapag hindi naman existing yung item sa cart, doon siya idadagdag as new entry sa arrays.
Dito papasok yung pag-store ng ID, quantity, at subtotal, tapos ina-update yung totalItems para alam ng system na may bagong laman na yung cart.

sa stock management naman, after ma-add yung item, binabawas na yung quantity sa stock ng product para updated lagi yung inventory. 
Dito po nagkaroon din ako ng issue dati kasi nababawasan agad kahit di pa pala confirmed yung add sa cart, kaya inadjust ko yung flow para mas tama.

s receipt part, iniisa-isa yung laman ng cart para kunin yung product name, quantity, at subtotal ng bawat item. 
Habang ginagawa ito, kino-compute din yung total amount sa pamamagitan ng pag-add ng lahat ng subtotal. 
Dito ko po naayos yung problema ko dati na mali yung total kasi hindi pala tama yung pag-add ko ng values.

pagkatapos po, chine-check kung umabot ba sa 5000 yung total. Kapag umabot, nag-a-apply ng 10% discount bago makuha yung final total. 
Simple lang siya pero important kasi dito pumapasok yung condition ng discount.

pinapakita rin yung updated stock ng lahat ng products para makita yung natitirang inventory after ng transaction. 
Sa dulo, may message din na thank you para matapos po yung process.



__________Enhanced ShoppingCartActivity_______________



Enhanced Shopping Cart System (Part 2)

About This Project
Ginawa ko yung project na to as continuation ng Part 1 namin na shopping cart system.

Sa Part 2, ang goal ko is mas mapaganda yung flow ng program lalo na sa cart management and checkout process. Nag add ako ng product search para mas mabilis maghanap ng items, then naglagay din ako ng cart menu para pwede na mag remove ng item or i-clear yung cart.

Nag improve din ako sa checkout by adding payment validation para hindi tumanggap ng kulang na payment. After checkout, nag gegenerate na rin ng receipt number, current date and time, pati change.

Nag add din ako ng low stock alert para makita kung aling products yung paubos na.

Sa order history naman, sine-save temporarily yung completed transactions habang tumatakbo yung program.


Features
Product Features
- View all available products
- Search products by product name
- Product categories
- Stock management

Cart Management
- Add item to cart
- View cart
- Remove item from cart
- Clear cart

Checkout Features
- Automatic subtotal calculation
- 10% discount for purchases above PHP 5000
- Payment validation
- Change computation
- Receipt generation

Receipt Details
Each checkout includes:
- Receipt number
- Date and time
- Payment amount
- Change

Stock Monitoring
- Updates stock after adding items
- Displays low stock alert when stock is 5 or below

Order History
Stores completed transactions during runtime:
- Receipt number
- Final total
- Order date/time



Part 2 Enhancements
The following features were added in Part 2:

- Refactored code structure into reusable methods
- Added product categories
- Added product search feature
- Added cart management menu
- Added remove item and clear cart functions
- Added payment validation and change computation
- Added receipt number and checkout date/time
- Added low stock alerts
- Added order history tracking



Sample Output

===== STORE MENU =====
1. View Products
2. Search Product
3. Add to Cart
4. Cart Menu
5. Checkout
6. View Order History

Choose option: 3
Enter product ID: 2
Enter quantity: 1
Item added to cart.

Grand Total: 18000
Discount: 1800
Final Total: 16200

Enter payment: 17000
Change: 800

===== RECEIPT =====
Receipt No: 0001
Date: 4/30/2026 10:25:00 PM
Payment: 17000
Change: 800



AI Usage Disclosure
AI was used as a learning and debugging assistant during development.

AI assistance included:
- reviewing the original shopping cart code
- suggesting cleaner method structure
- explaining logic for arrays, loops, and cart handling
- helping improve validation logic
- suggesting implementations for:
  - product search
  - cart management
  - payment validation
  - receipt generation
  - order history
  - stock alerts

All code suggestions were reviewed, tested, and manually integrated into the final program.

The developer still tested outputs, reviewed logic, and organized commits manually during development.


Commit History
Meaningful commits used during development:

- Refactor shopping cart structure and add categories
- Add product search and improve validation
- Add cart management menu
- Add checkout payment validation and cart updates
- Add receipt details order history and stock alerts

