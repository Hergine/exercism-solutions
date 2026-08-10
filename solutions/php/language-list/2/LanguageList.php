<?php

function language_list()
{
    // implement the language list function
    function language_list (string ...$languages):array
    {
        return $languages;
    }

    //Implement add_to_language_list function
    function add_to_language_list (array $language_list, string $language ):array
    {
        $language_list[] = $language;
        return $language_list;
    }

    //Implement prune_language_list function
    function prune_language_list (array $language_list):array
    {
        array_shift($language_list);
        return $language_list;
    }

    //Implement current_language function
    function current_language (array $language_list): string
    {
        return $language_list[0];
    }

    //Implement language_list_length function
    function language_list_length(array $language_list):int
    {
        return count(language_list);
    }
}
