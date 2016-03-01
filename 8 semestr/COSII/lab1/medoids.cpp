

Hashtable centersPoints = new Hashtable(clustCount);

// выделяю место под ассоциацию цент - точки
for (int i = 0; i < clustCount; i++)
{
    centersPoints[i] = new List<int>();
}

// выделяю место под параметры центров
centers = new ObjectParameters[clustCount];
for (int i = 0; i < centers.Length; i++)
    centers[i] = new ObjectParameters();

//рандомно расставляю центры по точкам
// take clustCount random numbers in range
//фиг знает, с 0 начинать или 1!!!!
var randomArray = Enumerable.Range(1/*0*/, objects.Length-1).OrderBy(t => random.Next()).Take(clustCount).ToArray();

for(int l=0; l < randomArray.Length; l++)
{
	centers[l] = objects[l]; //присваиваем инфу точки центру
	// или надо почленно перенести все измерения
}

//соотносим точки к центрам
double distance;
int flag = 0;
int claster;
int change = 0;

while(true)
{
	// начинать надо мб с 1
	for(i=0; i < objects.Length; i++) //точки на графике
	{
		int minDistance = 99999999999999;
		for(int c=0; c < centers.Length; c++) // центры кластеров на графике
		{
			if (objects[i] == centers[c]) //если точка и есть центр
				centersPoints[c].Add(i);
				break;
				/*flag =1;
				break;*/
			distance = calculateDistance(objects[i], centers[c]);
			if (distance < minDistance)
			{
				minDistance = distance;
				claster = c;
			}
		}
		/*if (flag)
		{
			flag = 0;
			continue;
		}*/

		if(centersPoints[claster].Contains(i))
			continue;
		else
		{
			deletePoint(i); // ф-я для прохода по всем спискам и удаления оттуда точки, если она уже там есть
			centersPoints[claster].Add(i);
			change = 1;
		}

	}


	//меняем местами центр с точками и рассчитываем самую лучшую комбинацию
	for(i=0; i< centersPoints.Length; i++) // для всех кластеров
	{
		int minLen = 99999999999999999999999;
		double len = 0;
		for (c=0; c < centersPoints[i].Length; c++) // для всех точек
		{
			len = calculateBestDistance(centersPoints[i][c], centersPoints[i]) //ф-я принимает центр(условный) и набор точек
			if(len< minLen)
			{
				minLen = len;
				futureCenter = centersPoints[i][c];
			}
		}
		// здесь првоерить, если центр поменялся, то поменять и его конфигурацию(метрики)
		if (centers[i] != objects[futureCenter])
		{
			change = 1;
			centers[i] = objects[futureCenter];
		}
	}

	if(!change)
		break;
	else 
	{
		for(i=0; i< centersPoints.Length; i++) // для всех кластеров
		{
			centersPoints[i].Clear;	
		}
	}
}
return table


public double calculateDistance(ObjectParameters obj, ObjectParameters center)
{
  double per = Math.Pow(obj.Perimeter - center.Perimeter, 2);
  double sq = Math.Pow(obj.Square - center.Square, 2);
  double el = Math.Pow(obj.elongation - center.elongation, 2);
  double comp = Math.Pow(obj.Compactness - center.Compactness, 2);
  return Math.Sqrt(per + sq + el + comp);
}

public double calculateBestDistance(int objectNum, List points)
{
	double len=0;
	for(int i=0; i<points.Length; i++)
	{
		len+=calculateDistance(objects[objectNum], objects[points[i]]);
	}
}