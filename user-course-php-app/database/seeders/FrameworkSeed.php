<?php

namespace Database\Seeders;

use App\Models\Framework;
use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class FrameworkSeed extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $frameworks = [
            [
                'name'=>'PHP',
                'description'=> 'backend',
            ],
            [
                'name'=>'Angular',
                'description'=> 'frontend',
            ],
            [
                'name'=>'React',
                'description'=> 'frontend',
            ],
        ];

        foreach ($frameworks as $framework){
            Framework::create($framework);
        }
    }
}
