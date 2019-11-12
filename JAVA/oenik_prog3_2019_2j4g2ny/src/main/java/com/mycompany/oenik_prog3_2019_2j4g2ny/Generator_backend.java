/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.oenik_prog3_2019_2j4g2ny;

import java.util.Random;

/**
 *
 * @author admin
 */
public class Generator_backend {
    private static final Random r = new Random();
    
    private static double GenRandom()
    {
        double max = 5.0;
        return r.nextDouble()*max;
    }
    
    public static int getObj(int price) 
    {
        int finalprice =  (int)Math.round(price * GenRandom());
        return finalprice;
    }
}
