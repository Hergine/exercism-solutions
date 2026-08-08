<?php

class PizzaPi
{
    public function calculateDoughRequirement($number_of_pizza, $number_of_person)
    {
        return($number_of_pizza * (($number_of_person*20) + 200));
    }

    public function calculateSauceRequirement($number_of_pizza, $sauce_can_volume)
    {
        return ($number_of_pizza * 125 / 250);
    }

    public function calculateCheeseCubeCoverage()
    {
        throw new \BadFunctionCallException("Implement the function");
    }

    public function calculateLeftOverSlices($cheese_dimension, $thickness, $diameter)
    {
        return (pow($cheese_dimension, 3) / ($thickness * pi() * $diameter));
    }
}
