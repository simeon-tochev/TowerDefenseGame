using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumLevel : Level {
    /* e - E. Coli
     * t - Tuberculosis
     * i - Influenze
     * c - Coronavirus
     * m - Malaria
     * n - Tetanus
     * p - Plague
     * b - Ebola
     */

    protected override void WaveSetup() {
        waves = new List<string>();
        waves.Add("eee");
        waves.Add("eeeeee");
        waves.Add("eeeeteeeee");
        waves.Add("ttttt");
        waves.Add("tteetttett");
        waves.Add("ttteeettttteeee");
        waves.Add("iiiii");
        waves.Add("iiittiii");
        waves.Add("iiittiieettieeiii");
        waves.Add("p");
        // 10
        waves.Add("nnnnnn");
        waves.Add("neeenneeenneeen");
        waves.Add("nnttttntttnn");
        waves.Add("nnniiinnnii");
        waves.Add("ninniininininin");
        waves.Add("nnittntninitniittnn");
        waves.Add("iiiiiiiiiiiiiiiiiiiiiiiiiii");
        waves.Add("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
        waves.Add("tttttttttttttttttttttttttttttttttttttttttttttttttttttttt");
        waves.Add("pppppppppppp");
        // 20
        waves.Add("mmmmm");
        waves.Add("miimmiimmmiiim");
        waves.Add("mmmmnnnnmmmmnnnnn");
        waves.Add("nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn");
        waves.Add("nnnnnntttttttttnnnnnnnnntttttiiiiinnnnn");
        waves.Add("iiiiiiiiiimmmttttttttttttnnnnnniiiiiiiiiiiimmmmtttttttnnn");
        waves.Add("mmmmmmmmmmmmmmmmmmmmmmmmmm");
        waves.Add("mmmmmmmmiiiiiiiiiiiiiiimmmmmmmmmmmmmmmiiiiiiiiiiimmmmmmmm");
        waves.Add("mmmmmmttttttttttttttttttttttttttttttttttttttttmmmmmmmmmmtttttttttttttttttttttttttt");
        waves.Add("b");
        // 30
        waves.Add("ccccccc");
        waves.Add("ciiiiiiiciiiiiiiiiciiiiiiiciiii");
        waves.Add("ccccnnnnnnccccnnnnnn");
        waves.Add("cccccccmmmmmmcccccccmmmcccc");
        waves.Add("ccccccccccccccccc");
        waves.Add("ccccttttttmmmmmmnnnnnccccttttmmmmnnnnncccc");
        waves.Add("cccccccccccccccccccccccccc");
        waves.Add("cccccccccccccmmmmmmmmmmmmmmmccccccccccccccc");
        waves.Add("cccccccccccnnnnnnnnnnnnmmmmmmmmmmmnnnnnnnnnnccccccccccccc");
        waves.Add("bbbbbbbbbbbbbbbbb");

        numWaves = waves.Count;
        waveHandler.Setup(waves, numWaves);
    }


}
