using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuahInfo
{
    public bool ubahBuah;
    public JenisBuah namaBuah;
    public Vector3 lokasi;

    public BuahInfo(bool ubahBuah, JenisBuah namaBuah, Vector3 lokasi)
    {
        this.ubahBuah = ubahBuah;
        this.namaBuah = namaBuah;
        this.lokasi = lokasi;
    }
}
