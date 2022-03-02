<?php

use App\Http\Controllers\CourseController;
use App\Http\Controllers\FrameworkController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

Route::get('/test', [CourseController::class, 'index']);

Route::get('/test2', [FrameworkController::class, 'index']);
