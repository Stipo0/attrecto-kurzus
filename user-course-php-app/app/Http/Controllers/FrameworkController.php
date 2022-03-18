<?php

namespace App\Http\Controllers;

use App\Http\Requests\FrameworkRequest;
use App\Http\Resources\FrameworkResource;
use App\Models\Framework;
use Symfony\Component\HttpFoundation\Response;
use Illuminate\Http\Request;

class FrameworkController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        return response()->json(
            FrameworkResource::collection(Framework::all()),
            Response::HTTP_OK
        );
    }

    /**
     * Store a newly created resource in storage.
     *
     * @return \Illuminate\Http\Response
     */
    public function store(FrameworkRequest $request)
    {
        $data =$request->all();
        $framework = Framework::create($data);
        return response()->json(
            FrameworkResource::make($framework),
            Response::HTTP_CREATED
        );
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        return response()->json(
            FrameworkResource::make(Framework::find($id)),
            Response::HTTP_OK
        );
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(FrameworkRequest $request, Framework $framework)
    {
        $data = $request->only([
            'name',
            'description',
        ]);
            $framework->name =$data['name'];
            $framework->description =$data['description'];
            $framework->save();

            return response()->json(
                FrameworkResource::make($framework),
                Response::HTTP_OK);
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy(Framework $framework)
    {
        $framework->delete();
        return response()->json(null,Response::HTTP_NO_CONTENT);
    }
}
