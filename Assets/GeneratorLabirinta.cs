using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLabirinta : MonoBehaviour
{
    [SerializeField] cvorLabirinta cvorPrefab;
    [SerializeField] Vector2Int velicinaLabirinta;

    private void Start()
    {
        generirajLabirint(velicinaLabirinta);
    }
    
    
    void generirajLabirint(Vector2Int size)
    {
        List<cvorLabirinta> cvorLista = new List<cvorLabirinta>();

        //kreiranje cvora
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3 pozicijaCvora = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f));
                cvorLabirinta cvor = Instantiate(cvorPrefab, pozicijaCvora, Quaternion.identity, transform);
                cvorLista.Add(cvor);
            }
        }

        List<cvorLabirinta> trenutnaPutanja = new List<cvorLabirinta>();
        List<cvorLabirinta> zavrseniCvor = new List<cvorLabirinta>();


        //Pocetna tocka
        trenutnaPutanja.Add(cvorLista[Random.Range(0, cvorLista.Count)]);

        while (zavrseniCvor.Count < cvorLista.Count)
        {
            List<int> moguciCvorovi = new List<int>();
            List<int> moguciSmjer = new List<int>();

            int indexCvora = cvorLista.IndexOf(trenutnaPutanja[trenutnaPutanja.Count - 1]);
            int cvorX = indexCvora / size.y;
            int cvorY = indexCvora % size.y;

            if (cvorX < size.x - 1)
            {
                if (!zavrseniCvor.Contains(cvorLista[indexCvora + size.y]) &&
                    !trenutnaPutanja.Contains(cvorLista[indexCvora + size.y]))
                {
                    moguciSmjer.Add(1);
                    moguciCvorovi.Add(indexCvora + size.y);
                }
            }

            if (cvorX > 0)
            {
                if (!zavrseniCvor.Contains(cvorLista[indexCvora - size.y]) &&
                    !trenutnaPutanja.Contains(cvorLista[indexCvora - size.y]))
                {
                    moguciSmjer.Add(2);
                    moguciCvorovi.Add(indexCvora - size.y);
                }
            }

            if (cvorY < size.y - 1)
            {
                if (!zavrseniCvor.Contains(cvorLista[indexCvora + 1]) &&
                    !trenutnaPutanja.Contains(cvorLista[indexCvora + 1]))
                {
                    moguciSmjer.Add(3);
                    moguciCvorovi.Add(indexCvora + 1);
                }
            }

            if (cvorY > 0)
            {
                if (!zavrseniCvor.Contains(cvorLista[indexCvora - 1]) &&
                    !trenutnaPutanja.Contains(cvorLista[indexCvora - 1]))
                {
                    moguciSmjer.Add(4);
                    moguciCvorovi.Add(indexCvora - 1);
                }
            }

            if (moguciSmjer.Count > 0)
            {
                int smjer = Random.Range(0, moguciSmjer.Count);
                cvorLabirinta odabraniCvor = cvorLista[moguciCvorovi[smjer]];

                switch (moguciSmjer[smjer])
                {
                    case 1:
                        odabraniCvor.micanjeZidova(1);
                        trenutnaPutanja[trenutnaPutanja.Count - 1].micanjeZidova(0);
                        break;

                    case 2:
                        odabraniCvor.micanjeZidova(0);
                        trenutnaPutanja[trenutnaPutanja.Count - 1].micanjeZidova(1);
                        break;

                    case 3:
                        odabraniCvor.micanjeZidova(3);
                        trenutnaPutanja[trenutnaPutanja.Count - 1].micanjeZidova(2);
                        break;

                    case 4:
                        odabraniCvor.micanjeZidova(2);
                        trenutnaPutanja[trenutnaPutanja.Count - 1].micanjeZidova(3);
                        break;

                }

                trenutnaPutanja.Add(odabraniCvor);
            }

            else
            {
                zavrseniCvor.Add(trenutnaPutanja[trenutnaPutanja.Count - 1]);
                trenutnaPutanja.RemoveAt(trenutnaPutanja.Count - 1);
            }
        }
    }
}
