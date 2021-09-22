void clamp(ref int sayi, int min, int max)
{
if(sayi < min)
{
sayi = min;
}else if(sayi > max)
{
sayi = max;
}
}

//VEYA

int clamp(int sayi, int min, int max)
{
if(sayi < min)
{
sayi = min;
}else if(sayi > max)
{
sayi = max;
}
return sayi;
}
