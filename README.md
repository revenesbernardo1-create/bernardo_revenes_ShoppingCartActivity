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
