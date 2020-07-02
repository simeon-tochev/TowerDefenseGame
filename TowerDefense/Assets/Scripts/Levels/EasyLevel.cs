using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyLevel : Level
{
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
        waves.Add("eeeee");
        waves.Add("eeeteeee");
        waves.Add("tttt");
        waves.Add("ttettett");
        waves.Add("ttteeettteeee");
        waves.Add("iiii");
        waves.Add("iiittii");
        waves.Add("iittieettieeii");
        waves.Add("p");
        // 10
        waves.Add("nnnn");
        waves.Add("neeeneeeneeen");
        waves.Add("nnttttnn");
        waves.Add("nniiinnii");
        waves.Add("ninininininin");
        waves.Add("nnittnitniittnn");
        waves.Add("iiiiiiiiiiiiiiiiiiii");
        waves.Add("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
        waves.Add("ttttttttttttttttttttttttttttttttttttttttttttttttttt");
        waves.Add("pppppppp");
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
