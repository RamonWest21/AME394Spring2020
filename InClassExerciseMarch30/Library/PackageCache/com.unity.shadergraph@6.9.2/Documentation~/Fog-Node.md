# Fog Node

## Description

Provides access to the Scene's **Fog** parameters.

Note: The behavior of this [Node](Node.md) is undefined globally. Shader Graph does not define the function of the node. Instead, each Render Pipeline defines what HLSL code to execute for this [Node](Node.md).

Different Render Pipelines may produce different results. If you're building a shader in one Render Pipeline that you want to use in both, try checking it in both pipelines before production. A [Node](Node.md) might be defined in one Render Pipeline and undefined in the other. If this [Node](Node.md) is undefined, it returns 0 (black).

#### Unity Pipelines Supported
- Lightweight Render Pipeline

## Ports

| Name        | Direction           | Type  | Binding | Description |
|:------------ |:-------------|:-----|:---|:---|
| Position      | Output | Vector 3 | Position (object space) | Mesh vertex/fragment's position |
| Color      | Output | Vector 4 | None | Fog color |
| Density       | Output | Vector 1 | None | Fog density at the vertex or fragment's clip space depth |

## Generated Code Example

The following example code represents one possible outcome of this node.

```
void Unity_Fog_float(float3 Position, out float4 Color, out float Density)
{
    SHADERGRAPH_FOG(Position, Color, Density);
}
```
