<?php

class LuckyNumbers
{
    public function sumUp(array $digitsOfNumber1, array $digitsOfNumber2):int
    {
        $numberOne = 0;
        $numberTwo = 0;

        foreach($digitsOfNumber1 as $digit)
        {
            $numberOne = $numberOne * 10 + $digit;
        }

        foreach($digitsOfNumber2 as $digit)
            {
                $numberTwo = $numberTwo * 10 + $digit;
            }

        return $numberOne + $numberTwo;

    }

    public function isPalindrome(int $number): bool
    {
        return (string)$number === strrev($number);
    }

    public function validate(string $input): string
    {
        if($input === '')
            {
                return 'Required field';
            }

        if((int)$input <=0 || !is_int((int)$number))
            {
                return 'Must be a whole number larger than 0';
            }

        return '';
    }
}

