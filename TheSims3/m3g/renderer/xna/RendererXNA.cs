// Decompiled with JetBrains decompiler
// Type: m3g.renderer.xna.RendererXNA
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sims3;
using System;
using System.Collections.Generic;

namespace m3g.renderer.xna
{
    public class RendererXNA : Renderer
    {
        private Stack<Matrix> modelMatrixStack = new Stack<Matrix>();
        private Vector3 tempOutVector = new Vector3();
        private const bool USE_SOFTWARE_SKINNING = true;
        private GraphicsDevice device;
        private Matrix projMat;
        private Matrix viewMat;
        private Matrix worldMat;
        private BasicEffect basicEffect;
        private DualTextureEffect multiTexture;
        private SkinnedEffect skinnedEffect;
        private AlphaTestEffect alphaTestEffect;
        private AppearanceBase m_cachedAppearance;
        private int numTex;
        private Fog m_cachedFog;
        private bool alphaTest;
        private Matrix[] m_matrixPalette;
        private BlendState blendStateAlpha;
        private BlendState blendStateAlphaAdd;
        private BlendState blendStateModulate;
        private BlendState blendStateModulatex2;
        private RasterizerState rasterStateCullClockwise;
        private RasterizerState rasterStateCullCounter;
        private RasterizerState rasterStateCullNone;
        private DepthStencilState depthStateNone;
        private DepthStencilState depthStateWriteOnly;
        private DepthStencilState depthStateBufferOnly;
        private DepthStencilState depthStateBoth;
        private SamplerState samplerStateWrapU;
        private SamplerState samplerStateWrapV;
        private SamplerState samplerStateWrap;
        private SamplerState samplerStateClamp;

        public RendererXNA(GraphicsDevice device)
        {
            this.modelMatrixStack.Push(Matrix.Identity);
            this.projMat = Matrix.Identity;
            this.viewMat = Matrix.Identity;
            this.basicEffect = new BasicEffect(device);
            this.multiTexture = new DualTextureEffect(device);
            this.skinnedEffect = new SkinnedEffect(device);
            this.skinnedEffect.WeightsPerVertex = 4;
            this.alphaTestEffect = new AlphaTestEffect(device);
            this.device = device;
            this.numTex = 0;
            this.m_cachedFog = (Fog)null;
            this.initBlendStates();
            this.initRasterStates();
            this.initDepthStates();
            this.initSamplerStates();
        }

        private void initBlendStates()
        {
            this.blendStateAlpha = new BlendState();
            this.blendStateAlpha.AlphaSourceBlend = Blend.SourceAlpha;
            this.blendStateAlpha.AlphaDestinationBlend = Blend.InverseSourceAlpha;
            this.blendStateAlpha.AlphaBlendFunction = BlendFunction.Add;
            this.blendStateAlpha.ColorSourceBlend = Blend.SourceAlpha;
            this.blendStateAlpha.ColorDestinationBlend = Blend.InverseSourceAlpha;
            this.blendStateAlphaAdd = new BlendState();
            this.blendStateAlphaAdd.AlphaSourceBlend = Blend.SourceAlpha;
            this.blendStateAlphaAdd.AlphaDestinationBlend = Blend.One;
            this.blendStateAlphaAdd.AlphaBlendFunction = BlendFunction.Add;
            this.blendStateAlphaAdd.ColorSourceBlend = Blend.SourceAlpha;
            this.blendStateAlphaAdd.ColorDestinationBlend = Blend.One;
            this.blendStateModulate = new BlendState();
            this.blendStateModulate.AlphaSourceBlend = Blend.DestinationColor;
            this.blendStateModulate.AlphaDestinationBlend = Blend.Zero;
            this.blendStateModulate.AlphaBlendFunction = BlendFunction.Add;
            this.blendStateModulate.ColorSourceBlend = Blend.DestinationColor;
            this.blendStateModulate.ColorDestinationBlend = Blend.Zero;
            this.blendStateModulatex2 = new BlendState();
            this.blendStateModulatex2.AlphaSourceBlend = Blend.DestinationColor;
            this.blendStateModulatex2.AlphaDestinationBlend = Blend.SourceColor;
            this.blendStateModulatex2.AlphaBlendFunction = BlendFunction.Add;
        }

        private void initRasterStates()
        {
            this.rasterStateCullClockwise = new RasterizerState();
            this.rasterStateCullClockwise.CullMode = CullMode.CullClockwiseFace;
            this.rasterStateCullClockwise.ScissorTestEnable = true;
            this.rasterStateCullCounter = new RasterizerState();
            this.rasterStateCullCounter.CullMode = CullMode.CullCounterClockwiseFace;
            this.rasterStateCullCounter.ScissorTestEnable = true;
            this.rasterStateCullNone = new RasterizerState();
            this.rasterStateCullNone.CullMode = CullMode.None;
            this.rasterStateCullNone.ScissorTestEnable = true;
        }

        private void initDepthStates()
        {
            this.depthStateNone = new DepthStencilState();
            this.depthStateNone.DepthBufferEnable = false;
            this.depthStateNone.DepthBufferWriteEnable = false;
            this.depthStateWriteOnly = new DepthStencilState();
            this.depthStateWriteOnly.DepthBufferEnable = false;
            this.depthStateWriteOnly.DepthBufferWriteEnable = true;
            this.depthStateBufferOnly = new DepthStencilState();
            this.depthStateBufferOnly.DepthBufferEnable = true;
            this.depthStateBufferOnly.DepthBufferWriteEnable = false;
            this.depthStateBoth = new DepthStencilState();
            this.depthStateBoth.DepthBufferEnable = true;
            this.depthStateBoth.DepthBufferWriteEnable = true;
        }

        private void initSamplerStates()
        {
            this.samplerStateWrapU = new SamplerState();
            this.samplerStateWrapU.AddressU = TextureAddressMode.Wrap;
            this.samplerStateWrapU.AddressV = TextureAddressMode.Clamp;
            this.samplerStateWrapV = new SamplerState();
            this.samplerStateWrapV.AddressU = TextureAddressMode.Clamp;
            this.samplerStateWrapV.AddressV = TextureAddressMode.Wrap;
            this.samplerStateWrap = new SamplerState();
            this.samplerStateWrap.AddressU = TextureAddressMode.Wrap;
            this.samplerStateWrap.AddressV = TextureAddressMode.Wrap;
            this.samplerStateClamp = new SamplerState();
            this.samplerStateClamp.AddressU = TextureAddressMode.Clamp;
            this.samplerStateClamp.AddressV = TextureAddressMode.Clamp;
        }

        public override void restoreToClamp()
        {
            this.device.SamplerStates[0] = this.samplerStateClamp;
        }

        public override void clear(Background background)
        {
            Color color1 = Color.Black;
            ClearOptions options = ClearOptions.Target;
            bool flag = false;
            if (background != null)
            {
                if (background.isColorClearEnabled())
                {
                    int color2 = background.getColor();
                    float num = 0.003921569f;
                    color1 = new Color((float)((color2 & 16711680) >> 16) * num, (float)((color2 & 65280) >> 8) * num, (float)(color2 & (int)byte.MaxValue) * num) * ((float)(((long)color2 & 4278190080L) >> 24) * num);
                    flag = true;
                }
                if (background.isDepthClearEnabled())
                {
                    if (background.isColorClearEnabled())
                    {
                        options |= ClearOptions.DepthBuffer;
                        flag = true;
                    }
                    else
                    {
                        options = ClearOptions.DepthBuffer;
                        flag = true;
                    }
                }
            }
            else
            {
                options = ClearOptions.Target | ClearOptions.DepthBuffer;
                flag = true;
            }
            if (!flag)
                return;
            this.device.Clear(options, color1, 1f, 0);
        }

        public override void setViewport(int x, int y, int width, int height)
        {
            int x1 = Math.Min(Math.Max(0, x), TheSims3.target.Width);
            int y1 = Math.Min(Math.Max(0, y), TheSims3.target.Height);
            int width1 = Math.Min(width - (x1 - x), TheSims3.target.Width - x1);
            int height1 = Math.Min(height - (y1 - y), TheSims3.target.Height - y1);
            this.device.Viewport = new Viewport(x1, y1, width1, height1);
        }

        public override void bind(int w, int h)
        {
            this.m_cachedAppearance = (AppearanceBase)null;
            this.m_cachedFog = (Fog)null;
            this.clearEffects();
        }

        public override void popModelTransform()
        {
        }

        public override void pushModelTransform(Transform transform)
        {
            transform.get(ref this.worldMat);
        }

        public void clearEffects()
        {
            this.basicEffect.Texture = (Microsoft.Xna.Framework.Graphics.Texture2D)null;
            this.multiTexture.Texture = (Microsoft.Xna.Framework.Graphics.Texture2D)null;
            this.multiTexture.Texture2 = (Microsoft.Xna.Framework.Graphics.Texture2D)null;
            this.skinnedEffect.Texture = (Microsoft.Xna.Framework.Graphics.Texture2D)null;
        }

        private void processTexture(m3g.Texture2D texture)
        {
            if (texture == null)
                return;
            this.device.SamplerStates[0] = texture.getWrappingS() != 241 || texture.getWrappingT() != 241 ? (texture.getWrappingS() != 240 || texture.getWrappingT() != 240 ? (texture.getWrappingS() != 241 || texture.getWrappingT() != 240 ? this.samplerStateWrapV : this.samplerStateWrapU) : this.samplerStateClamp) : this.samplerStateWrap;
            if (this.numTex == 0)
            {
                this.basicEffect.Texture = texture.getImage().texture2d;
                this.basicEffect.TextureEnabled = true;
                this.skinnedEffect.Texture = texture.getImage().texture2d;
                this.alphaTestEffect.Texture = texture.getImage().texture2d;
            }
            else
            {
                this.multiTexture.Texture = this.basicEffect.Texture;
                this.multiTexture.Texture2 = texture.getImage().texture2d;
            }
            ++this.numTex;
        }

        public override void processApperance(Appearance appearance)
        {
            this.numTex = 0;
            for (int index = 0; index < appearance.getNumTextures(); ++index)
                this.processTexture(appearance.getTexture(index));
            if (this.numTex == 0)
                this.basicEffect.TextureEnabled = false;
            if (appearance.getPolygonMode() != null)
            {
                CullMode cullMode = CullMode.CullClockwiseFace;
                switch (appearance.getPolygonMode().getWinding())
                {
                    case 168:
                        cullMode = CullMode.CullClockwiseFace;
                        break;
                    case 169:
                        cullMode = CullMode.CullCounterClockwiseFace;
                        break;
                }
                switch (appearance.getPolygonMode().getCulling())
                {
                    case 160:
                        this.device.RasterizerState = cullMode != CullMode.CullClockwiseFace ? this.rasterStateCullCounter : this.rasterStateCullClockwise;
                        break;
                    case 161:
                        this.device.RasterizerState = cullMode != CullMode.CullClockwiseFace ? this.rasterStateCullClockwise : this.rasterStateCullCounter;
                        break;
                    case 162:
                        this.device.RasterizerState = this.rasterStateCullNone;
                        break;
                }
            }
            else
                this.device.RasterizerState = this.rasterStateCullClockwise;
            CompositingMode compositingMode = appearance.getCompositingMode();
            if (compositingMode == null)
            {
                this.device.DepthStencilState = DepthStencilState.Default;
                this.device.BlendState = BlendState.Opaque;
            }
            else
            {
                float alphaThreshold = compositingMode.getAlphaThreshold();
                if ((double)alphaThreshold < 0.00392156885936856)
                {
                    this.alphaTest = false;
                }
                else
                {
                    this.alphaTestEffect.AlphaFunction = CompareFunction.Greater;
                    this.alphaTestEffect.ReferenceAlpha = (int)((double)alphaThreshold * (double)byte.MaxValue);
                    this.alphaTest = true;
                }
                this.device.DepthStencilState = !compositingMode.isDepthTestEnabled() || !compositingMode.isDepthWriteEnabled() ? (compositingMode.isDepthTestEnabled() || compositingMode.isDepthWriteEnabled() ? (!compositingMode.isDepthTestEnabled() || compositingMode.isDepthWriteEnabled() ? this.depthStateWriteOnly : this.depthStateBufferOnly) : this.depthStateNone) : this.depthStateBoth;
                switch (compositingMode.getBlending())
                {
                    case 64:
                        this.device.BlendState = this.blendStateAlpha;
                        break;
                    case 65:
                        this.device.BlendState = this.blendStateAlphaAdd;
                        break;
                    case 66:
                        this.device.BlendState = this.blendStateModulate;
                        break;
                    case 67:
                        this.device.BlendState = this.blendStateModulatex2;
                        break;
                    case 69:
                        this.device.BlendState = BlendState.Additive;
                        break;
                    case 71:
                        this.device.BlendState = BlendState.AlphaBlend;
                        break;
                    default:
                        this.device.BlendState = BlendState.Opaque;
                        break;
                }
            }
            Fog fog = appearance.getFog();
            if (fog == null)
            {
                this.basicEffect.FogEnabled = false;
                this.multiTexture.FogEnabled = false;
            }
            else
            {
                if (fog == this.m_cachedFog)
                    return;
                int color = fog.getColor();
                Vector3 vector3 = new Vector3();
                float num = 0.003921569f;
                vector3.X = (float)((color & 16711680) >> 16) * num;
                vector3.Y = (float)((color & 65280) >> 8) * num;
                vector3.Z = (float)(color & (int)byte.MaxValue) * num;
                this.basicEffect.FogColor = this.multiTexture.FogColor = vector3;
                this.basicEffect.FogStart = this.multiTexture.FogStart = fog.getNearDistance();
                this.basicEffect.FogEnd = this.multiTexture.FogEnd = fog.getFarDistance();
                this.basicEffect.FogEnabled = this.multiTexture.FogEnabled = true;
            }
        }

        public override void render(
          m3g.VertexBuffer vertices,
          m3g.IndexBuffer primitives,
          AppearanceBase appearance,
          float alphaFactor)
        {
            if (appearance != this.m_cachedAppearance)
            {
                this.processApperance((Appearance)appearance);
                this.m_cachedAppearance = appearance;
            }
            this.renderIndexBuffer(primitives, vertices, alphaFactor);
        }

        public override void render(
          m3g.VertexBuffer vertices,
          VertexArray skinIndices,
          VertexArray skinWeights,
          Matrix[] matrixPalette,
          m3g.IndexBuffer primitives,
          AppearanceBase appearance,
          float alphaFactor)
        {
            this.m_matrixPalette = matrixPalette;
            this.processVertexBufferPositionsSoftwareSkinned(vertices);
            if (appearance != this.m_cachedAppearance)
            {
                this.processApperance((Appearance)appearance);
                this.m_cachedAppearance = appearance;
            }
            ushort[] stripLengths = primitives.getStripLengths();
            short[] explicitIndices = primitives.getExplicitIndices();
            bool flag1 = primitives.isStripped();
            bool flag2 = primitives.isImplicit();
            int primitiveType1 = primitives.getPrimitiveType();
            PrimitiveType primitiveType2 = PrimitiveType.TriangleStrip;
            Vertex[] vertexDataTransformed = vertices.skinVertexDataTransformed;
            Effect effect;
            if (this.alphaTest)
            {
                effect = (Effect)this.alphaTestEffect;
                this.alphaTestEffect.View = this.viewMat;
                this.alphaTestEffect.Projection = this.projMat;
                this.alphaTestEffect.World = this.worldMat;
                int defaultColor = vertices.getDefaultColor();
                this.alphaTestEffect.DiffuseColor = vertices.getXnaDiffuse();
                this.alphaTestEffect.Alpha = (float)(defaultColor >> 24 & (int)byte.MaxValue) / (float)byte.MaxValue * alphaFactor;
                this.alphaTestEffect.VertexColorEnabled = vertices.getColors() != null;
            }
            else
            {
                effect = (Effect)this.basicEffect;
                this.basicEffect.View = this.viewMat;
                this.basicEffect.Projection = this.projMat;
                this.basicEffect.World = this.worldMat;
                int defaultColor = vertices.getDefaultColor();
                this.basicEffect.DiffuseColor = vertices.getXnaDiffuse();
                this.basicEffect.Alpha = (float)(defaultColor >> 24 & (int)byte.MaxValue) / (float)byte.MaxValue * alphaFactor;
                this.basicEffect.VertexColorEnabled = vertices.getColors() != null && !this.basicEffect.TextureEnabled;
            }
            for (int index1 = 0; index1 < effect.CurrentTechnique.Passes.Count; ++index1)
            {
                effect.CurrentTechnique.Passes[index1].Apply();
                switch (primitiveType1)
                {
                    case 8:
                        primitiveType2 = !flag1 ? PrimitiveType.TriangleList : PrimitiveType.TriangleStrip;
                        break;
                    case 9:
                        primitiveType2 = !flag1 ? PrimitiveType.LineList : PrimitiveType.LineStrip;
                        break;
                    case 10:
                        primitiveType2 = PrimitiveType.TriangleStrip;
                        if (!flag1)
                            break;
                        break;
                }
                if (flag1)
                {
                    int length = stripLengths.Length;
                    ushort[] numArray = stripLengths;
                    if (!flag2)
                    {
                        short[] indexData = explicitIndices;
                        int indexOffset = 0;
                        for (int index2 = 0; index2 < length; ++index2)
                        {
                            int num = (int)numArray[index2];
                            int primitiveCount = 1 + (num - 3);
                            this.device.DrawUserIndexedPrimitives<Vertex>(primitiveType2, vertexDataTransformed, 0, vertices.getVertexCount(), indexData, indexOffset, primitiveCount);
                            indexOffset += num;
                        }
                    }
                    else
                    {
                        int firstIndex = primitives.getFirstIndex();
                        for (int index2 = 0; index2 < length; ++index2)
                        {
                            int num = (int)numArray[index2];
                            int primitiveCount = 1 + (num - 3);
                            this.device.DrawUserPrimitives<Vertex>(primitiveType2, vertexDataTransformed, firstIndex, primitiveCount);
                            firstIndex += num;
                        }
                    }
                }
                else
                {
                    int primitiveCount = primitives.getPrimitiveCount();
                    if (!flag2)
                    {
                        short[] indexData = explicitIndices;
                        this.device.DrawUserIndexedPrimitives<Vertex>(primitiveType2, vertexDataTransformed, 0, vertices.getVertexCount(), indexData, 0, primitiveCount);
                    }
                    else
                    {
                        int firstIndex = primitives.getFirstIndex();
                        this.device.DrawUserPrimitives<Vertex>(primitiveType2, vertexDataTransformed, firstIndex, primitiveCount);
                    }
                }
            }
        }

        private void renderIndexBuffer(
          m3g.IndexBuffer primitives,
          m3g.VertexBuffer vertices,
          float alphaFactor)
        {
            ushort[] stripLengths = primitives.getStripLengths();
            short[] explicitIndices = primitives.getExplicitIndices();
            bool flag1 = primitives.isStripped();
            bool flag2 = primitives.isImplicit();
            int primitiveType1 = primitives.getPrimitiveType();
            PrimitiveType primitiveType2 = PrimitiveType.TriangleStrip;
            Vertex[] finalVertices = vertices.getFinalVertices();
            Effect effect;
            if (this.alphaTest)
            {
                effect = (Effect)this.alphaTestEffect;
                this.alphaTestEffect.View = this.viewMat;
                this.alphaTestEffect.Projection = this.projMat;
                this.alphaTestEffect.World = this.worldMat;
                int defaultColor = vertices.getDefaultColor();
                this.alphaTestEffect.DiffuseColor = vertices.getXnaDiffuse();
                this.alphaTestEffect.Alpha = (float)(defaultColor >> 24 & (int)byte.MaxValue) / (float)byte.MaxValue * alphaFactor;
                this.alphaTestEffect.VertexColorEnabled = vertices.getColors() != null;
            }
            else
            {
                effect = (Effect)this.basicEffect;
                this.basicEffect.View = this.viewMat;
                this.basicEffect.Projection = this.projMat;
                this.basicEffect.World = this.worldMat;
                int defaultColor = vertices.getDefaultColor();
                this.basicEffect.DiffuseColor = vertices.getXnaDiffuse();
                this.basicEffect.Alpha = (float)(defaultColor >> 24 & (int)byte.MaxValue) / (float)byte.MaxValue * alphaFactor;
                this.basicEffect.VertexColorEnabled = vertices.getColors() != null && !this.basicEffect.TextureEnabled;
            }
            for (int index1 = 0; index1 < effect.CurrentTechnique.Passes.Count; ++index1)
            {
                effect.CurrentTechnique.Passes[index1].Apply();
                switch (primitiveType1)
                {
                    case 8:
                        primitiveType2 = !flag1 ? PrimitiveType.TriangleList : PrimitiveType.TriangleStrip;
                        break;
                    case 9:
                        primitiveType2 = !flag1 ? PrimitiveType.LineList : PrimitiveType.LineStrip;
                        break;
                    case 10:
                        primitiveType2 = PrimitiveType.TriangleStrip;
                        if (!flag1)
                            break;
                        break;
                }
                if (flag1)
                {
                    int length = stripLengths.Length;
                    ushort[] numArray = stripLengths;
                    if (!flag2)
                    {
                        short[] indexData = explicitIndices;
                        int indexOffset = 0;
                        for (int index2 = 0; index2 < length; ++index2)
                        {
                            int num = (int)numArray[index2];
                            int primitiveCount = 1 + (num - 3);
                            this.device.DrawUserIndexedPrimitives<Vertex>(primitiveType2, finalVertices, 0, vertices.getVertexCount(), indexData, indexOffset, primitiveCount);
                            indexOffset += num;
                        }
                    }
                    else
                    {
                        int firstIndex = primitives.getFirstIndex();
                        for (int index2 = 0; index2 < length; ++index2)
                        {
                            int num = (int)numArray[index2];
                            int primitiveCount = 1 + (num - 3);
                            this.device.DrawUserPrimitives<Vertex>(primitiveType2, finalVertices, firstIndex, primitiveCount);
                            firstIndex += num;
                        }
                    }
                }
                else
                {
                    int primitiveCount = primitives.getPrimitiveCount();
                    if (!flag2)
                    {
                        short[] indexData = explicitIndices;
                        this.device.DrawUserIndexedPrimitives<Vertex>(primitiveType2, finalVertices, 0, vertices.getVertexCount(), indexData, 0, primitiveCount);
                    }
                    else
                    {
                        int firstIndex = primitives.getFirstIndex();
                        this.device.DrawUserPrimitives<Vertex>(primitiveType2, finalVertices, firstIndex, primitiveCount);
                    }
                }
            }
        }

        public override void setProjectionAndViewTransform(Transform projection, Transform view)
        {
            projection.get(ref this.projMat);
            view.get(ref this.viewMat);
        }

        public override void release()
        {
        }

        private void Transform(ref Vector3 vector, ref Matrix matrix, ref Vector3 result)
        {
            float num1 = (float)((double)vector.X * (double)matrix.M11 + (double)vector.Y * (double)matrix.M21 + (double)vector.Z * (double)matrix.M31) + matrix.M41;
            float num2 = (float)((double)vector.X * (double)matrix.M12 + (double)vector.Y * (double)matrix.M22 + (double)vector.Z * (double)matrix.M32) + matrix.M42;
            float num3 = (float)((double)vector.X * (double)matrix.M13 + (double)vector.Y * (double)matrix.M23 + (double)vector.Z * (double)matrix.M33) + matrix.M43;
            result.X = num1;
            result.Y = num2;
            result.Z = num3;
        }

        private void processVertexBufferPositionsSoftwareSkinned(m3g.VertexBuffer vb)
        {
            if (vb.skinVertexDataTransformed == null)
                vb.setSkinTransformed();
            int vertexCount = vb.getVertexCount();
            Vertex[] vertexDataTransformed = vb.skinVertexDataTransformed;
            Vertex[] finalVertexData = vb.finalVertexData;
            for (int index1 = 0; index1 < vertexCount; ++index1)
            {
                vertexDataTransformed[index1].position.X = 0.0f;
                vertexDataTransformed[index1].position.Y = 0.0f;
                vertexDataTransformed[index1].position.Z = 0.0f;
                if ((double)vertexDataTransformed[index1].skinWeight.X != 0.0)
                {
                    int index2 = (int)vertexDataTransformed[index1].skinIndex.X & (int)byte.MaxValue;
                    this.Transform(ref finalVertexData[index1].position, ref this.m_matrixPalette[index2], ref this.tempOutVector);
                    vertexDataTransformed[index1].position.X += vertexDataTransformed[index1].skinWeight.X * this.tempOutVector.X;
                    vertexDataTransformed[index1].position.Y += vertexDataTransformed[index1].skinWeight.X * this.tempOutVector.Y;
                    vertexDataTransformed[index1].position.Z += vertexDataTransformed[index1].skinWeight.X * this.tempOutVector.Z;
                }
                if ((double)vertexDataTransformed[index1].skinWeight.Y != 0.0)
                {
                    int index2 = (int)vertexDataTransformed[index1].skinIndex.Y & (int)byte.MaxValue;
                    this.Transform(ref finalVertexData[index1].position, ref this.m_matrixPalette[index2], ref this.tempOutVector);
                    vertexDataTransformed[index1].position.X += vertexDataTransformed[index1].skinWeight.Y * this.tempOutVector.X;
                    vertexDataTransformed[index1].position.Y += vertexDataTransformed[index1].skinWeight.Y * this.tempOutVector.Y;
                    vertexDataTransformed[index1].position.Z += vertexDataTransformed[index1].skinWeight.Y * this.tempOutVector.Z;
                }
                if ((double)vertexDataTransformed[index1].skinWeight.Z != 0.0)
                {
                    int index2 = (int)vertexDataTransformed[index1].skinIndex.Z & (int)byte.MaxValue;
                    this.Transform(ref finalVertexData[index1].position, ref this.m_matrixPalette[index2], ref this.tempOutVector);
                    vertexDataTransformed[index1].position.X += vertexDataTransformed[index1].skinWeight.Z * this.tempOutVector.X;
                    vertexDataTransformed[index1].position.Y += vertexDataTransformed[index1].skinWeight.Z * this.tempOutVector.Y;
                    vertexDataTransformed[index1].position.Z += vertexDataTransformed[index1].skinWeight.Z * this.tempOutVector.Z;
                }
                if ((double)vertexDataTransformed[index1].skinWeight.W != 0.0)
                {
                    int index2 = (int)vertexDataTransformed[index1].skinIndex.W & (int)byte.MaxValue;
                    this.Transform(ref finalVertexData[index1].position, ref this.m_matrixPalette[index2], ref this.tempOutVector);
                    vertexDataTransformed[index1].position.X += vertexDataTransformed[index1].skinWeight.W * this.tempOutVector.X;
                    vertexDataTransformed[index1].position.Y += vertexDataTransformed[index1].skinWeight.W * this.tempOutVector.Y;
                    vertexDataTransformed[index1].position.Z += vertexDataTransformed[index1].skinWeight.W * this.tempOutVector.Z;
                }
            }
        }
    }
}
