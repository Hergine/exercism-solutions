<?php

class HighSchoolSweetheart
{
    public function firstLetter(string $name): string
    {
        //Getting rif of spaces
        $clean_name = str_replace(" ", '', $name);

        //Returning the first letter
        return substr($clean_name, 0, 1);
    }

    public function initial(string $name): string
    {
        return strtoupper($this->firstLetter($name)) . ".";
    }

    public function initials(string $name): string
    {
        $clean_name = trim($name);
        [$firstName, $lastName] = explode(" ", $clean_name);
        return $this->initial($firstName) . " " . $this->initial($lastName);
    }

    public function pair(string $sweetheart_a, string $sweetheart_b): string
    {
        $a = $this->initials($sweetheart_a);
        $b = $this->initials($sweetheart_b);

        return "     ******       ******\n" .
           "   **      **   **      **\n" .
           " **          ** **          **\n" .
           "**            *            **\n" .
           "**                         **\n" .
           "**     $a  +  $b     **\n" .
           " **                       **\n" .
           "   **                   **\n" .
           "     **               **\n" .
           "       **           **\n" .
           "         **       **\n" .
           "           **   **\n" .
           "             ***\n" .
           "              *";
               
    }
}
