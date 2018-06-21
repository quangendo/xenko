// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Reflection;
using Xenko.Core.Annotations;
using Xenko.Core.Storage;

namespace Xenko.Core.Serialization
{
    public static unsafe class MemberNullableSerializer
    {
        public static void SerializeExtended([NotNull] SerializationStream stream, Type objType, ref object obj, ArchiveMode mode, DataSerializer dataSerializer = null)
        {
            var context = stream.Context;

            if (objType.GetTypeInfo().IsValueType)
            {
                if (dataSerializer == null)
                {
                    dataSerializer = context.SerializerSelector.GetSerializer(objType);

                    // If we still have no serializer, throw an exception
                    if (dataSerializer == null)
                        throw new ArgumentException("No serializer available for type " + objType.FullName);
                }

                // Structure, no need to check for inheritance or null values.
                dataSerializer.Serialize(ref obj, mode, stream);

                return;
            }



            if (mode == ArchiveMode.Serialize)
            {
                if (ReferenceEquals(obj, null))
                {
                    // Null contentRef
                    stream.Write((byte)SerializeClassFlags.IsNull);
                }
                else
                {




                    // Serialize flags
                    stream.Write((byte)SerializeClassFlags.None);

                    {
                        if (dataSerializer == null)
                        {
                            dataSerializer = context.SerializerSelector.GetSerializer(objType);

                            // If we still have no serializer, throw an exception
                            if (dataSerializer == null)
                                throw new ArgumentException("No serializer available for type " + objType.FullName);
                        }

                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);
                        dataSerializer.Serialize(ref obj, mode, stream);
                    }
                }
            }
            else
            {

                var isNull = ((SerializeClassFlags)stream.ReadByte() & SerializeClassFlags.IsNull) == SerializeClassFlags.IsNull;

                if (isNull)
                {
                    obj = null;
                }
                else
                {
                    {
                        if (dataSerializer == null)
                        {
                            dataSerializer = context.SerializerSelector.GetSerializer(objType);

                            // If we still have no serializer, throw an exception
                            if (dataSerializer == null)
                                throw new ArgumentException("No serializer available for type " + objType.FullName);
                        }

                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);


                        dataSerializer.Serialize(ref obj, mode, stream);
                    }

                }
            }
        }
    }

    public unsafe class MemberNullableSerializer<T> : MemberSerializer<T>
    {
        public MemberNullableSerializer(DataSerializer<T> dataSerializer) : base(dataSerializer)
        {
        }

        public override void Serialize(ref T obj, ArchiveMode mode, SerializationStream stream)
        {



            if (mode == ArchiveMode.Serialize)
            {
                if (ReferenceEquals(obj, null))
                {
                    // Null contentRef
                    stream.Write((byte)SerializeClassFlags.IsNull);
                }
                else
                {




                    // Serialize flags
                    stream.Write((byte)SerializeClassFlags.None);

                    {
                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);
                        dataSerializer.Serialize(ref obj, mode, stream);
                    }
                }
            }
            else
            {

                var isNull = ((SerializeClassFlags)stream.ReadByte() & SerializeClassFlags.IsNull) == SerializeClassFlags.IsNull;

                if (isNull)
                {
                    obj = default(T);
                }
                else
                {
                    {
                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);


                        dataSerializer.Serialize(ref obj, mode, stream);
                    }

                }
            }
        }

        internal static void SerializeExtended(ref T obj, ArchiveMode mode, [NotNull] SerializationStream stream, DataSerializer<T> dataSerializer = null)
        {
            var context = stream.Context;

            if (isValueType)
            {
                if (dataSerializer == null)
                {
                    dataSerializer = (DataSerializer<T>)context.SerializerSelector.GetSerializer(typeof(T));

                    // If we still have no serializer, throw an exception
                    if (dataSerializer == null)
                        throw new ArgumentException("No serializer available for type " + typeof(T).FullName);
                }

                // Structure, no need to check for inheritance or null values.
                dataSerializer.Serialize(ref obj, mode, stream);

                return;
            }



            if (mode == ArchiveMode.Serialize)
            {
                if (ReferenceEquals(obj, null))
                {
                    // Null contentRef
                    stream.Write((byte)SerializeClassFlags.IsNull);
                }
                else
                {




                    // Serialize flags
                    stream.Write((byte)SerializeClassFlags.None);

                    {
                        if (dataSerializer == null)
                        {
                            dataSerializer = (DataSerializer<T>)context.SerializerSelector.GetSerializer(typeof(T));

                            // If we still have no serializer, throw an exception
                            if (dataSerializer == null)
                                throw new ArgumentException("No serializer available for type " + typeof(T).FullName);
                        }

                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);
                        dataSerializer.Serialize(ref obj, mode, stream);
                    }
                }
            }
            else
            {

                var isNull = ((SerializeClassFlags)stream.ReadByte() & SerializeClassFlags.IsNull) == SerializeClassFlags.IsNull;

                if (isNull)
                {
                    obj = default(T);
                }
                else
                {
                    {
                        if (dataSerializer == null)
                        {
                            dataSerializer = (DataSerializer<T>)context.SerializerSelector.GetSerializer(typeof(T));

                            // If we still have no serializer, throw an exception
                            if (dataSerializer == null)
                                throw new ArgumentException("No serializer available for type " + typeof(T).FullName);
                        }

                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);


                        dataSerializer.Serialize(ref obj, mode, stream);
                    }

                }
            }
        }
    }

    public unsafe class MemberNullableSerializerObject<T> : MemberSerializer<T>
    {
        public MemberNullableSerializerObject(DataSerializer<T> dataSerializer) : base(dataSerializer)
        {
        }

        public override void Serialize(ref T obj, ArchiveMode mode, SerializationStream stream)
        {

            if (isValueType)
            {

                // Structure, no need to check for inheritance or null values.
                dataSerializer.Serialize(ref obj, mode, stream);

                return;
            }



            if (mode == ArchiveMode.Serialize)
            {
                if (ReferenceEquals(obj, null))
                {
                    // Null contentRef
                    stream.Write((byte)SerializeClassFlags.IsNull);
                }
                else
                {




                    // Serialize flags
                    stream.Write((byte)SerializeClassFlags.None);

                    {
                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);
                        dataSerializer.Serialize(ref obj, mode, stream);
                    }
                }
            }
            else
            {

                var isNull = ((SerializeClassFlags)stream.ReadByte() & SerializeClassFlags.IsNull) == SerializeClassFlags.IsNull;

                if (isNull)
                {
                    obj = default(T);
                }
                else
                {
                    {
                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);


                        dataSerializer.Serialize(ref obj, mode, stream);
                    }

                }
            }
        }
    }

    public static unsafe class MemberNonSealedSerializer
    {
        public static void SerializeExtended([NotNull] SerializationStream stream, Type objType, ref object obj, ArchiveMode mode, DataSerializer dataSerializer = null)
        {
            var context = stream.Context;

            if (objType.GetTypeInfo().IsValueType)
            {
                if (dataSerializer == null)
                {
                    dataSerializer = context.SerializerSelector.GetSerializer(objType);

                    // If we still have no serializer, throw an exception
                    if (dataSerializer == null)
                        throw new ArgumentException("No serializer available for type " + objType.FullName);
                }

                // Structure, no need to check for inheritance or null values.
                dataSerializer.Serialize(ref obj, mode, stream);

                return;
            }


            // Serialize either with dataSerializer if obj is really of type T, otherwise look for appropriate serializer.
            SerializeClassFlags flags;
            bool hasTypeInfo;
            DataSerializer objectDataSerializer;
            Type type;

            if (mode == ArchiveMode.Serialize)
            {
                if (ReferenceEquals(obj, null))
                {
                    // Null contentRef
                    stream.Write((byte)SerializeClassFlags.IsNull);
                }
                else
                {
                    flags = SerializeClassFlags.None;



                    // If real type is not expected type, we need to store type info as well.
                    var expectedType = objType;
                    type = objType.GetTypeInfo().IsSealed ? expectedType : obj.GetType();
                    hasTypeInfo = type != expectedType;
                    objectDataSerializer = null;
                    if (hasTypeInfo)
                    {
                        // Find matching serializer (always required w/ typeinfo, since type was different than expected)
                        objectDataSerializer = context.SerializerSelector.GetSerializer(type);

                        if (objectDataSerializer == null)
                            throw new ArgumentException("No serializer available for type " + type.FullName);

                        // Update expected type
                        type = objectDataSerializer.SerializationType;

                        // Special case: serializer reports the actual serialized type, and it might actually match the expected type
                        // (i.e. there is a hidden inherited type, such as PropertyInfo/RuntimePropertyInfo).
                        // Let's detect it here.
                        if (type == expectedType)
                        {
                            // Cancel type info
                            hasTypeInfo = false;
                        }
                        else
                        {
                            // Continue as expected with type info
                            flags |= SerializeClassFlags.IsTypeInfo;
                        }
                    }

                    // Serialize flags
                    stream.Write((byte)flags);

                    if (hasTypeInfo)
                    {
                        // Serialize type info
                        fixed (ObjectId* serializationTypeId = &objectDataSerializer.SerializationTypeId)
                            stream.Serialize((IntPtr)serializationTypeId, ObjectId.HashSize);

                        // Serialize object
                        objectDataSerializer.PreSerialize(ref obj, mode, stream);
                        objectDataSerializer.Serialize(ref obj, mode, stream);
                    }
                    else
                    {
                        if (dataSerializer == null)
                        {
                            dataSerializer = context.SerializerSelector.GetSerializer(expectedType);

                            // If we still have no serializer, throw an exception
                            if (dataSerializer == null)
                                throw new ArgumentException("No serializer available for type " + expectedType.FullName);
                        }

                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);
                        dataSerializer.Serialize(ref obj, mode, stream);
                    }
                }
            }
            else
            {

                flags = (SerializeClassFlags)stream.ReadByte();
                var isNull = (flags & SerializeClassFlags.IsNull) == SerializeClassFlags.IsNull;
                hasTypeInfo = (flags & SerializeClassFlags.IsTypeInfo) == SerializeClassFlags.IsTypeInfo;

                if (isNull)
                {
                    obj = null;
                }
                else
                {
                    if (hasTypeInfo)
                    {
                        ObjectId serializationTypeId;
                        stream.Serialize((IntPtr)Interop.FixedOut(out serializationTypeId), ObjectId.HashSize);

                        objectDataSerializer = context.SerializerSelector.GetSerializer(ref serializationTypeId);
						if (objectDataSerializer == null)
						    throw new ArgumentException("No serializer available for type id " + serializationTypeId + " and base type " + objType.FullName);

                        objectDataSerializer.PreSerialize(ref obj, mode, stream);


                        objectDataSerializer.Serialize(ref obj, mode, stream);
                    }
                    else
                    {
                        if (dataSerializer == null)
                        {
                            dataSerializer = context.SerializerSelector.GetSerializer(objType);

                            // If we still have no serializer, throw an exception
                            if (dataSerializer == null)
                                throw new ArgumentException("No serializer available for type " + objType.FullName);
                        }

                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);


                        dataSerializer.Serialize(ref obj, mode, stream);
                    }

                }
            }
        }
    }

    public unsafe class MemberNonSealedSerializer<T> : MemberSerializer<T>
    {
        public MemberNonSealedSerializer(DataSerializer<T> dataSerializer) : base(dataSerializer)
        {
        }

        public override void Serialize(ref T obj, ArchiveMode mode, SerializationStream stream)
        {
            var context = stream.Context;


            // Serialize either with dataSerializer if obj is really of type T, otherwise look for appropriate serializer.
            SerializeClassFlags flags;
            bool hasTypeInfo;
            object objCopy;
            DataSerializer objectDataSerializer;
            Type type;

            if (mode == ArchiveMode.Serialize)
            {
                if (ReferenceEquals(obj, null))
                {
                    // Null contentRef
                    stream.Write((byte)SerializeClassFlags.IsNull);
                }
                else
                {
                    flags = SerializeClassFlags.None;



                    // If real type is not expected type, we need to store type info as well.
                    var expectedType = typeof(T);
                    type = isSealed ? expectedType : obj.GetType();
                    hasTypeInfo = type != expectedType;
                    objectDataSerializer = null;
                    if (hasTypeInfo)
                    {
                        // Find matching serializer (always required w/ typeinfo, since type was different than expected)
                        objectDataSerializer = context.SerializerSelector.GetSerializer(type);

                        if (objectDataSerializer == null)
                            throw new ArgumentException("No serializer available for type " + type.FullName);

                        // Update expected type
                        type = objectDataSerializer.SerializationType;

                        // Special case: serializer reports the actual serialized type, and it might actually match the expected type
                        // (i.e. there is a hidden inherited type, such as PropertyInfo/RuntimePropertyInfo).
                        // Let's detect it here.
                        if (type == expectedType)
                        {
                            // Cancel type info
                            hasTypeInfo = false;
                        }
                        else
                        {
                            // Continue as expected with type info
                            flags |= SerializeClassFlags.IsTypeInfo;
                        }
                    }

                    // Serialize flags
                    stream.Write((byte)flags);

                    if (hasTypeInfo)
                    {
                        // Serialize type info
                        fixed (ObjectId* serializationTypeId = &objectDataSerializer.SerializationTypeId)
                            stream.Serialize((IntPtr)serializationTypeId, ObjectId.HashSize);

                        // Serialize object
                        objCopy = obj;
                        objectDataSerializer.PreSerialize(ref objCopy, mode, stream);
                        objectDataSerializer.Serialize(ref objCopy, mode, stream);
                        obj = (T)objCopy;
                    }
                    else
                    {
                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);
                        dataSerializer.Serialize(ref obj, mode, stream);
                    }
                }
            }
            else
            {

                flags = (SerializeClassFlags)stream.ReadByte();
                var isNull = (flags & SerializeClassFlags.IsNull) == SerializeClassFlags.IsNull;
                hasTypeInfo = (flags & SerializeClassFlags.IsTypeInfo) == SerializeClassFlags.IsTypeInfo;

                if (isNull)
                {
                    obj = default(T);
                }
                else
                {
                    if (hasTypeInfo)
                    {
                        ObjectId serializationTypeId;
                        stream.Serialize((IntPtr)Interop.FixedOut(out serializationTypeId), ObjectId.HashSize);

                        objectDataSerializer = context.SerializerSelector.GetSerializer(ref serializationTypeId);
						if (objectDataSerializer == null)
						    throw new ArgumentException("No serializer available for type id " + serializationTypeId + " and base type " + typeof(T).FullName);

                        objCopy = obj;
                        objectDataSerializer.PreSerialize(ref objCopy, mode, stream);


                        objectDataSerializer.Serialize(ref objCopy, mode, stream);
                        obj = (T)objCopy;
                    }
                    else
                    {
                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);


                        dataSerializer.Serialize(ref obj, mode, stream);
                    }

                }
            }
        }

        internal static void SerializeExtended(ref T obj, ArchiveMode mode, [NotNull] SerializationStream stream, DataSerializer<T> dataSerializer = null)
        {
            var context = stream.Context;

            if (isValueType)
            {
                if (dataSerializer == null)
                {
                    dataSerializer = (DataSerializer<T>)context.SerializerSelector.GetSerializer(typeof(T));

                    // If we still have no serializer, throw an exception
                    if (dataSerializer == null)
                        throw new ArgumentException("No serializer available for type " + typeof(T).FullName);
                }

                // Structure, no need to check for inheritance or null values.
                dataSerializer.Serialize(ref obj, mode, stream);

                return;
            }


            // Serialize either with dataSerializer if obj is really of type T, otherwise look for appropriate serializer.
            SerializeClassFlags flags;
            bool hasTypeInfo;
            object objCopy;
            DataSerializer objectDataSerializer;
            Type type;

            if (mode == ArchiveMode.Serialize)
            {
                if (ReferenceEquals(obj, null))
                {
                    // Null contentRef
                    stream.Write((byte)SerializeClassFlags.IsNull);
                }
                else
                {
                    flags = SerializeClassFlags.None;



                    // If real type is not expected type, we need to store type info as well.
                    var expectedType = typeof(T);
                    type = isSealed ? expectedType : obj.GetType();
                    hasTypeInfo = type != expectedType;
                    objectDataSerializer = null;
                    if (hasTypeInfo)
                    {
                        // Find matching serializer (always required w/ typeinfo, since type was different than expected)
                        objectDataSerializer = context.SerializerSelector.GetSerializer(type);

                        if (objectDataSerializer == null)
                            throw new ArgumentException("No serializer available for type " + type.FullName);

                        // Update expected type
                        type = objectDataSerializer.SerializationType;

                        // Special case: serializer reports the actual serialized type, and it might actually match the expected type
                        // (i.e. there is a hidden inherited type, such as PropertyInfo/RuntimePropertyInfo).
                        // Let's detect it here.
                        if (type == expectedType)
                        {
                            // Cancel type info
                            hasTypeInfo = false;
                        }
                        else
                        {
                            // Continue as expected with type info
                            flags |= SerializeClassFlags.IsTypeInfo;
                        }
                    }

                    // Serialize flags
                    stream.Write((byte)flags);

                    if (hasTypeInfo)
                    {
                        // Serialize type info
                        fixed (ObjectId* serializationTypeId = &objectDataSerializer.SerializationTypeId)
                            stream.Serialize((IntPtr)serializationTypeId, ObjectId.HashSize);

                        // Serialize object
                        objCopy = obj;
                        objectDataSerializer.PreSerialize(ref objCopy, mode, stream);
                        objectDataSerializer.Serialize(ref objCopy, mode, stream);
                        obj = (T)objCopy;
                    }
                    else
                    {
                        if (dataSerializer == null)
                        {
                            dataSerializer = (DataSerializer<T>)context.SerializerSelector.GetSerializer(expectedType);

                            // If we still have no serializer, throw an exception
                            if (dataSerializer == null)
                                throw new ArgumentException("No serializer available for type " + expectedType.FullName);
                        }

                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);
                        dataSerializer.Serialize(ref obj, mode, stream);
                    }
                }
            }
            else
            {

                flags = (SerializeClassFlags)stream.ReadByte();
                var isNull = (flags & SerializeClassFlags.IsNull) == SerializeClassFlags.IsNull;
                hasTypeInfo = (flags & SerializeClassFlags.IsTypeInfo) == SerializeClassFlags.IsTypeInfo;

                if (isNull)
                {
                    obj = default(T);
                }
                else
                {
                    if (hasTypeInfo)
                    {
                        ObjectId serializationTypeId;
                        stream.Serialize((IntPtr)Interop.FixedOut(out serializationTypeId), ObjectId.HashSize);

                        objectDataSerializer = context.SerializerSelector.GetSerializer(ref serializationTypeId);
						if (objectDataSerializer == null)
						    throw new ArgumentException("No serializer available for type id " + serializationTypeId + " and base type " + typeof(T).FullName);

                        objCopy = obj;
                        objectDataSerializer.PreSerialize(ref objCopy, mode, stream);


                        objectDataSerializer.Serialize(ref objCopy, mode, stream);
                        obj = (T)objCopy;
                    }
                    else
                    {
                        if (dataSerializer == null)
                        {
                            dataSerializer = (DataSerializer<T>)context.SerializerSelector.GetSerializer(typeof(T));

                            // If we still have no serializer, throw an exception
                            if (dataSerializer == null)
                                throw new ArgumentException("No serializer available for type " + typeof(T).FullName);
                        }

                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);


                        dataSerializer.Serialize(ref obj, mode, stream);
                    }

                }
            }
        }
    }

    public unsafe class MemberNonSealedSerializerObject<T> : MemberSerializer<T>
    {
        public MemberNonSealedSerializerObject(DataSerializer<T> dataSerializer) : base(dataSerializer)
        {
        }

        public override void Serialize(ref T obj, ArchiveMode mode, SerializationStream stream)
        {
            var context = stream.Context;

            if (isValueType)
            {

                // Structure, no need to check for inheritance or null values.
                dataSerializer.Serialize(ref obj, mode, stream);

                return;
            }


            // Serialize either with dataSerializer if obj is really of type T, otherwise look for appropriate serializer.
            SerializeClassFlags flags;
            bool hasTypeInfo;
            object objCopy;
            DataSerializer objectDataSerializer;
            Type type;

            if (mode == ArchiveMode.Serialize)
            {
                if (ReferenceEquals(obj, null))
                {
                    // Null contentRef
                    stream.Write((byte)SerializeClassFlags.IsNull);
                }
                else
                {
                    flags = SerializeClassFlags.None;



                    // If real type is not expected type, we need to store type info as well.
                    var expectedType = typeof(T);
                    type = isSealed ? expectedType : obj.GetType();
                    hasTypeInfo = type != expectedType;
                    objectDataSerializer = null;
                    if (hasTypeInfo)
                    {
                        // Find matching serializer (always required w/ typeinfo, since type was different than expected)
                        objectDataSerializer = context.SerializerSelector.GetSerializer(type);

                        if (objectDataSerializer == null)
                            throw new ArgumentException("No serializer available for type " + type.FullName);

                        // Update expected type
                        type = objectDataSerializer.SerializationType;

                        // Special case: serializer reports the actual serialized type, and it might actually match the expected type
                        // (i.e. there is a hidden inherited type, such as PropertyInfo/RuntimePropertyInfo).
                        // Let's detect it here.
                        if (type == expectedType)
                        {
                            // Cancel type info
                            hasTypeInfo = false;
                        }
                        else
                        {
                            // Continue as expected with type info
                            flags |= SerializeClassFlags.IsTypeInfo;
                        }
                    }

                    // Serialize flags
                    stream.Write((byte)flags);

                    if (hasTypeInfo)
                    {
                        // Serialize type info
                        fixed (ObjectId* serializationTypeId = &objectDataSerializer.SerializationTypeId)
                            stream.Serialize((IntPtr)serializationTypeId, ObjectId.HashSize);

                        // Serialize object
                        objCopy = obj;
                        objectDataSerializer.PreSerialize(ref objCopy, mode, stream);
                        objectDataSerializer.Serialize(ref objCopy, mode, stream);
                        obj = (T)objCopy;
                    }
                    else
                    {
                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);
                        dataSerializer.Serialize(ref obj, mode, stream);
                    }
                }
            }
            else
            {

                flags = (SerializeClassFlags)stream.ReadByte();
                var isNull = (flags & SerializeClassFlags.IsNull) == SerializeClassFlags.IsNull;
                hasTypeInfo = (flags & SerializeClassFlags.IsTypeInfo) == SerializeClassFlags.IsTypeInfo;

                if (isNull)
                {
                    obj = default(T);
                }
                else
                {
                    if (hasTypeInfo)
                    {
                        ObjectId serializationTypeId;
                        stream.Serialize((IntPtr)Interop.FixedOut(out serializationTypeId), ObjectId.HashSize);

                        objectDataSerializer = context.SerializerSelector.GetSerializer(ref serializationTypeId);
						if (objectDataSerializer == null)
						    throw new ArgumentException("No serializer available for type id " + serializationTypeId + " and base type " + typeof(T).FullName);

                        objCopy = obj;
                        objectDataSerializer.PreSerialize(ref objCopy, mode, stream);


                        objectDataSerializer.Serialize(ref objCopy, mode, stream);
                        obj = (T)objCopy;
                    }
                    else
                    {
                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);


                        dataSerializer.Serialize(ref obj, mode, stream);
                    }

                }
            }
        }
    }

    public static unsafe class MemberReuseSerializer
    {
        public static void SerializeExtended([NotNull] SerializationStream stream, Type objType, ref object obj, ArchiveMode mode, DataSerializer dataSerializer = null)
        {
            var context = stream.Context;

            if (objType.GetTypeInfo().IsValueType)
            {
                if (dataSerializer == null)
                {
                    dataSerializer = context.SerializerSelector.GetSerializer(objType);

                    // If we still have no serializer, throw an exception
                    if (dataSerializer == null)
                        throw new ArgumentException("No serializer available for type " + objType.FullName);
                }

                // Structure, no need to check for inheritance or null values.
                dataSerializer.Serialize(ref obj, mode, stream);

                return;
            }


            // Serialize either with dataSerializer if obj is really of type T, otherwise look for appropriate serializer.
            SerializeClassFlags flags;
            bool reuseReferences = context.SerializerSelector.ReuseReferences;
            int index;
            bool externalIdentifiableAsGuid = context.SerializerSelector.ExternalIdentifiableAsGuid;
            bool hasTypeInfo;
            DataSerializer objectDataSerializer;
            Type type;

            if (mode == ArchiveMode.Serialize)
            {
                if (ReferenceEquals(obj, null))
                {
                    // Null contentRef
                    stream.Write((byte)SerializeClassFlags.IsNull);
                }
                else
                {
                    flags = SerializeClassFlags.None;

                    if (externalIdentifiableAsGuid)
                    {
                        var identifiable = obj as IIdentifiable;
                        var externalIdentifiables = context.Get(MemberSerializer.ExternalIdentifiables);
                        if (identifiable != null && externalIdentifiables?.ContainsKey(identifiable.Id) == true)
                        {
                            flags |= SerializeClassFlags.IsExternalIdentifiable;
                            stream.Write((byte)flags);
                            stream.Write(identifiable.Id);
                            return;
                        }
                    }

                    index = -1;
                    if (reuseReferences)
                    {
                        var objectReferences = context.Get(MemberSerializer.ObjectSerializeReferences);
                        if (objectReferences.TryGetValue(obj, out index))
                        {
                            // Already serialized, just write its contentRef index
                            flags |= SerializeClassFlags.IsReference;
                            stream.Write((byte)flags);
                            stream.Write(index);
                            return;
                        }

                        // First time it is serialized, add it to objectReferences.
                        objectReferences.Add(obj, index = objectReferences.Count);
                    }

                    // If real type is not expected type, we need to store type info as well.
                    var expectedType = objType;
                    type = objType.GetTypeInfo().IsSealed ? expectedType : obj.GetType();
                    hasTypeInfo = type != expectedType;
                    objectDataSerializer = null;
                    if (hasTypeInfo)
                    {
                        // Find matching serializer (always required w/ typeinfo, since type was different than expected)
                        objectDataSerializer = context.SerializerSelector.GetSerializer(type);

                        if (objectDataSerializer == null)
                            throw new ArgumentException("No serializer available for type " + type.FullName);

                        // Update expected type
                        type = objectDataSerializer.SerializationType;

                        // Special case: serializer reports the actual serialized type, and it might actually match the expected type
                        // (i.e. there is a hidden inherited type, such as PropertyInfo/RuntimePropertyInfo).
                        // Let's detect it here.
                        if (type == expectedType)
                        {
                            // Cancel type info
                            hasTypeInfo = false;
                        }
                        else
                        {
                            // Continue as expected with type info
                            flags |= SerializeClassFlags.IsTypeInfo;
                        }
                    }

                    // Serialize flags
                    stream.Write((byte)flags);

                    // Serialize object index (if required)
                    if (reuseReferences)
                        stream.Write(index);

                    if (hasTypeInfo)
                    {
                        // Serialize type info
                        fixed (ObjectId* serializationTypeId = &objectDataSerializer.SerializationTypeId)
                            stream.Serialize((IntPtr)serializationTypeId, ObjectId.HashSize);

                        // Serialize object
                        objectDataSerializer.PreSerialize(ref obj, mode, stream);
                        objectDataSerializer.Serialize(ref obj, mode, stream);
                    }
                    else
                    {
                        if (dataSerializer == null)
                        {
                            dataSerializer = context.SerializerSelector.GetSerializer(expectedType);

                            // If we still have no serializer, throw an exception
                            if (dataSerializer == null)
                                throw new ArgumentException("No serializer available for type " + expectedType.FullName);
                        }

                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);
                        dataSerializer.Serialize(ref obj, mode, stream);
                    }
                }
            }
            else
            {

                flags = (SerializeClassFlags)stream.ReadByte();
                var isNull = (flags & SerializeClassFlags.IsNull) == SerializeClassFlags.IsNull;
                var objectReferences = reuseReferences ? context.Get(MemberSerializer.ObjectDeserializeReferences) : null;
                var referenceCallback = reuseReferences ? context.Get(MemberSerializer.ObjectDeserializeCallback) : null;
                var isReference = (flags & SerializeClassFlags.IsReference) == SerializeClassFlags.IsReference;
                var isExternalIdentifiable = (flags & SerializeClassFlags.IsExternalIdentifiable) == SerializeClassFlags.IsExternalIdentifiable;
                index = reuseReferences && !isNull && !isExternalIdentifiable ? stream.ReadInt32() : -1;
                hasTypeInfo = (flags & SerializeClassFlags.IsTypeInfo) == SerializeClassFlags.IsTypeInfo;

                if (isNull)
                {
                    obj = null;
                }
                else if (externalIdentifiableAsGuid && isExternalIdentifiable)
                {
                    var externalIdentifiables = context.Get(MemberSerializer.ExternalIdentifiables);
					var identifier = stream.Read<Guid>();
					IIdentifiable identifiable;
					externalIdentifiables.TryGetValue(identifier, out identifiable);
                    obj = identifiable;
                }
                else if (reuseReferences && isReference)
                {
                    obj = objectReferences[index];
                }
                else
                {
                    if (reuseReferences)
                    {
                        if (objectReferences.Count != index)
                            throw new InvalidOperationException("Serialization contentRef indices are out of sync.");
                        objectReferences.Add(null);
                    }
                    if (hasTypeInfo)
                    {
                        ObjectId serializationTypeId;
                        stream.Serialize((IntPtr)Interop.FixedOut(out serializationTypeId), ObjectId.HashSize);

                        objectDataSerializer = context.SerializerSelector.GetSerializer(ref serializationTypeId);
						if (objectDataSerializer == null)
						    throw new ArgumentException("No serializer available for type id " + serializationTypeId + " and base type " + objType.FullName);

                        objectDataSerializer.PreSerialize(ref obj, mode, stream);

                        if (reuseReferences)
                        {
                            // Register object so that later references to it are working.
                            objectReferences[index] = obj;
                        }

                        objectDataSerializer.Serialize(ref obj, mode, stream);
                    }
                    else
                    {
                        if (dataSerializer == null)
                        {
                            dataSerializer = context.SerializerSelector.GetSerializer(objType);

                            // If we still have no serializer, throw an exception
                            if (dataSerializer == null)
                                throw new ArgumentException("No serializer available for type " + objType.FullName);
                        }

                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);

                        if (reuseReferences)
                        {
                            // Register object so that later references to it are working.
                            objectReferences[index] = obj;
                        }

                        dataSerializer.Serialize(ref obj, mode, stream);
                    }

                    if (reuseReferences)
                    {
                        // Register object so that later references to it are working.
                        objectReferences[index] = obj;

                        // Call Reference Callback
                        referenceCallback?.Invoke(index, obj);
                    }
                }
            }
        }
    }

    public unsafe class MemberReuseSerializer<T> : MemberSerializer<T>
    {
        public MemberReuseSerializer(DataSerializer<T> dataSerializer) : base(dataSerializer)
        {
        }

        public override void Serialize(ref T obj, ArchiveMode mode, SerializationStream stream)
        {
            var context = stream.Context;


            // Serialize either with dataSerializer if obj is really of type T, otherwise look for appropriate serializer.
            SerializeClassFlags flags;
            bool reuseReferences = context.SerializerSelector.ReuseReferences;
            int index;
            bool externalIdentifiableAsGuid = context.SerializerSelector.ExternalIdentifiableAsGuid;
            bool hasTypeInfo;
            object objCopy;
            DataSerializer objectDataSerializer;
            Type type;

            if (mode == ArchiveMode.Serialize)
            {
                if (ReferenceEquals(obj, null))
                {
                    // Null contentRef
                    stream.Write((byte)SerializeClassFlags.IsNull);
                }
                else
                {
                    flags = SerializeClassFlags.None;

                    if (externalIdentifiableAsGuid)
                    {
                        var identifiable = obj as IIdentifiable;
                        var externalIdentifiables = context.Get(MemberSerializer.ExternalIdentifiables);
                        if (identifiable != null && externalIdentifiables?.ContainsKey(identifiable.Id) == true)
                        {
                            flags |= SerializeClassFlags.IsExternalIdentifiable;
                            stream.Write((byte)flags);
                            stream.Write(identifiable.Id);
                            return;
                        }
                    }

                    index = -1;
                    if (reuseReferences)
                    {
                        var objectReferences = context.Get(MemberSerializer.ObjectSerializeReferences);
                        if (objectReferences.TryGetValue(obj, out index))
                        {
                            // Already serialized, just write its contentRef index
                            flags |= SerializeClassFlags.IsReference;
                            stream.Write((byte)flags);
                            stream.Write(index);
                            return;
                        }

                        // First time it is serialized, add it to objectReferences.
                        objectReferences.Add(obj, index = objectReferences.Count);
                    }

                    // If real type is not expected type, we need to store type info as well.
                    var expectedType = typeof(T);
                    type = isSealed ? expectedType : obj.GetType();
                    hasTypeInfo = type != expectedType;
                    objectDataSerializer = null;
                    if (hasTypeInfo)
                    {
                        // Find matching serializer (always required w/ typeinfo, since type was different than expected)
                        objectDataSerializer = context.SerializerSelector.GetSerializer(type);

                        if (objectDataSerializer == null)
                            throw new ArgumentException("No serializer available for type " + type.FullName);

                        // Update expected type
                        type = objectDataSerializer.SerializationType;

                        // Special case: serializer reports the actual serialized type, and it might actually match the expected type
                        // (i.e. there is a hidden inherited type, such as PropertyInfo/RuntimePropertyInfo).
                        // Let's detect it here.
                        if (type == expectedType)
                        {
                            // Cancel type info
                            hasTypeInfo = false;
                        }
                        else
                        {
                            // Continue as expected with type info
                            flags |= SerializeClassFlags.IsTypeInfo;
                        }
                    }

                    // Serialize flags
                    stream.Write((byte)flags);

                    // Serialize object index (if required)
                    if (reuseReferences)
                        stream.Write(index);

                    if (hasTypeInfo)
                    {
                        // Serialize type info
                        fixed (ObjectId* serializationTypeId = &objectDataSerializer.SerializationTypeId)
                            stream.Serialize((IntPtr)serializationTypeId, ObjectId.HashSize);

                        // Serialize object
                        objCopy = obj;
                        objectDataSerializer.PreSerialize(ref objCopy, mode, stream);
                        objectDataSerializer.Serialize(ref objCopy, mode, stream);
                        obj = (T)objCopy;
                    }
                    else
                    {
                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);
                        dataSerializer.Serialize(ref obj, mode, stream);
                    }
                }
            }
            else
            {

                flags = (SerializeClassFlags)stream.ReadByte();
                var isNull = (flags & SerializeClassFlags.IsNull) == SerializeClassFlags.IsNull;
                var objectReferences = reuseReferences ? context.Get(MemberSerializer.ObjectDeserializeReferences) : null;
                var referenceCallback = reuseReferences ? context.Get(MemberSerializer.ObjectDeserializeCallback) : null;
                var isReference = (flags & SerializeClassFlags.IsReference) == SerializeClassFlags.IsReference;
                var isExternalIdentifiable = (flags & SerializeClassFlags.IsExternalIdentifiable) == SerializeClassFlags.IsExternalIdentifiable;
                index = reuseReferences && !isNull && !isExternalIdentifiable ? stream.ReadInt32() : -1;
                hasTypeInfo = (flags & SerializeClassFlags.IsTypeInfo) == SerializeClassFlags.IsTypeInfo;

                if (isNull)
                {
                    obj = default(T);
                }
                else if (externalIdentifiableAsGuid && isExternalIdentifiable)
                {
                    var externalIdentifiables = context.Get(MemberSerializer.ExternalIdentifiables);
					var identifier = stream.Read<Guid>();
					IIdentifiable identifiable;
					externalIdentifiables.TryGetValue(identifier, out identifiable);
                    obj = (T)identifiable;
                }
                else if (reuseReferences && isReference)
                {
                    obj = (T)objectReferences[index];
                }
                else
                {
                    if (reuseReferences)
                    {
                        if (objectReferences.Count != index)
                            throw new InvalidOperationException("Serialization contentRef indices are out of sync.");
                        objectReferences.Add(null);
                    }
                    if (hasTypeInfo)
                    {
                        ObjectId serializationTypeId;
                        stream.Serialize((IntPtr)Interop.FixedOut(out serializationTypeId), ObjectId.HashSize);

                        objectDataSerializer = context.SerializerSelector.GetSerializer(ref serializationTypeId);
						if (objectDataSerializer == null)
						    throw new ArgumentException("No serializer available for type id " + serializationTypeId + " and base type " + typeof(T).FullName);

                        objCopy = obj;
                        objectDataSerializer.PreSerialize(ref objCopy, mode, stream);

                        if (reuseReferences)
                        {
                            // Register object so that later references to it are working.
                            objectReferences[index] = objCopy;
                        }

                        objectDataSerializer.Serialize(ref objCopy, mode, stream);
                        obj = (T)objCopy;
                    }
                    else
                    {
                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);

                        if (reuseReferences)
                        {
                            // Register object so that later references to it are working.
                            objectReferences[index] = obj;
                        }

                        dataSerializer.Serialize(ref obj, mode, stream);
                    }

                    if (reuseReferences)
                    {
                        // Register object so that later references to it are working.
                        objectReferences[index] = obj;

                        // Call Reference Callback
                        referenceCallback?.Invoke(index, obj);
                    }
                }
            }
        }

        internal static void SerializeExtended(ref T obj, ArchiveMode mode, [NotNull] SerializationStream stream, DataSerializer<T> dataSerializer = null)
        {
            var context = stream.Context;

            if (isValueType)
            {
                if (dataSerializer == null)
                {
                    dataSerializer = (DataSerializer<T>)context.SerializerSelector.GetSerializer(typeof(T));

                    // If we still have no serializer, throw an exception
                    if (dataSerializer == null)
                        throw new ArgumentException("No serializer available for type " + typeof(T).FullName);
                }

                // Structure, no need to check for inheritance or null values.
                dataSerializer.Serialize(ref obj, mode, stream);

                return;
            }


            // Serialize either with dataSerializer if obj is really of type T, otherwise look for appropriate serializer.
            SerializeClassFlags flags;
            bool reuseReferences = context.SerializerSelector.ReuseReferences;
            int index;
            bool externalIdentifiableAsGuid = context.SerializerSelector.ExternalIdentifiableAsGuid;
            bool hasTypeInfo;
            object objCopy;
            DataSerializer objectDataSerializer;
            Type type;

            if (mode == ArchiveMode.Serialize)
            {
                if (ReferenceEquals(obj, null))
                {
                    // Null contentRef
                    stream.Write((byte)SerializeClassFlags.IsNull);
                }
                else
                {
                    flags = SerializeClassFlags.None;

                    if (externalIdentifiableAsGuid)
                    {
                        var identifiable = obj as IIdentifiable;
                        var externalIdentifiables = context.Get(MemberSerializer.ExternalIdentifiables);
                        if (identifiable != null && externalIdentifiables?.ContainsKey(identifiable.Id) == true)
                        {
                            flags |= SerializeClassFlags.IsExternalIdentifiable;
                            stream.Write((byte)flags);
                            stream.Write(identifiable.Id);
                            return;
                        }
                    }

                    index = -1;
                    if (reuseReferences)
                    {
                        var objectReferences = context.Get(MemberSerializer.ObjectSerializeReferences);
                        if (objectReferences.TryGetValue(obj, out index))
                        {
                            // Already serialized, just write its contentRef index
                            flags |= SerializeClassFlags.IsReference;
                            stream.Write((byte)flags);
                            stream.Write(index);
                            return;
                        }

                        // First time it is serialized, add it to objectReferences.
                        objectReferences.Add(obj, index = objectReferences.Count);
                    }

                    // If real type is not expected type, we need to store type info as well.
                    var expectedType = typeof(T);
                    type = isSealed ? expectedType : obj.GetType();
                    hasTypeInfo = type != expectedType;
                    objectDataSerializer = null;
                    if (hasTypeInfo)
                    {
                        // Find matching serializer (always required w/ typeinfo, since type was different than expected)
                        objectDataSerializer = context.SerializerSelector.GetSerializer(type);

                        if (objectDataSerializer == null)
                            throw new ArgumentException("No serializer available for type " + type.FullName);

                        // Update expected type
                        type = objectDataSerializer.SerializationType;

                        // Special case: serializer reports the actual serialized type, and it might actually match the expected type
                        // (i.e. there is a hidden inherited type, such as PropertyInfo/RuntimePropertyInfo).
                        // Let's detect it here.
                        if (type == expectedType)
                        {
                            // Cancel type info
                            hasTypeInfo = false;
                        }
                        else
                        {
                            // Continue as expected with type info
                            flags |= SerializeClassFlags.IsTypeInfo;
                        }
                    }

                    // Serialize flags
                    stream.Write((byte)flags);

                    // Serialize object index (if required)
                    if (reuseReferences)
                        stream.Write(index);

                    if (hasTypeInfo)
                    {
                        // Serialize type info
                        fixed (ObjectId* serializationTypeId = &objectDataSerializer.SerializationTypeId)
                            stream.Serialize((IntPtr)serializationTypeId, ObjectId.HashSize);

                        // Serialize object
                        objCopy = obj;
                        objectDataSerializer.PreSerialize(ref objCopy, mode, stream);
                        objectDataSerializer.Serialize(ref objCopy, mode, stream);
                        obj = (T)objCopy;
                    }
                    else
                    {
                        if (dataSerializer == null)
                        {
                            dataSerializer = (DataSerializer<T>)context.SerializerSelector.GetSerializer(expectedType);

                            // If we still have no serializer, throw an exception
                            if (dataSerializer == null)
                                throw new ArgumentException("No serializer available for type " + expectedType.FullName);
                        }

                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);
                        dataSerializer.Serialize(ref obj, mode, stream);
                    }
                }
            }
            else
            {

                flags = (SerializeClassFlags)stream.ReadByte();
                var isNull = (flags & SerializeClassFlags.IsNull) == SerializeClassFlags.IsNull;
                var objectReferences = reuseReferences ? context.Get(MemberSerializer.ObjectDeserializeReferences) : null;
                var referenceCallback = reuseReferences ? context.Get(MemberSerializer.ObjectDeserializeCallback) : null;
                var isReference = (flags & SerializeClassFlags.IsReference) == SerializeClassFlags.IsReference;
                var isExternalIdentifiable = (flags & SerializeClassFlags.IsExternalIdentifiable) == SerializeClassFlags.IsExternalIdentifiable;
                index = reuseReferences && !isNull && !isExternalIdentifiable ? stream.ReadInt32() : -1;
                hasTypeInfo = (flags & SerializeClassFlags.IsTypeInfo) == SerializeClassFlags.IsTypeInfo;

                if (isNull)
                {
                    obj = default(T);
                }
                else if (externalIdentifiableAsGuid && isExternalIdentifiable)
                {
                    var externalIdentifiables = context.Get(MemberSerializer.ExternalIdentifiables);
					var identifier = stream.Read<Guid>();
					IIdentifiable identifiable;
					externalIdentifiables.TryGetValue(identifier, out identifiable);
                    obj = (T)identifiable;
                }
                else if (reuseReferences && isReference)
                {
                    obj = (T)objectReferences[index];
                }
                else
                {
                    if (reuseReferences)
                    {
                        if (objectReferences.Count != index)
                            throw new InvalidOperationException("Serialization contentRef indices are out of sync.");
                        objectReferences.Add(null);
                    }
                    if (hasTypeInfo)
                    {
                        ObjectId serializationTypeId;
                        stream.Serialize((IntPtr)Interop.FixedOut(out serializationTypeId), ObjectId.HashSize);

                        objectDataSerializer = context.SerializerSelector.GetSerializer(ref serializationTypeId);
						if (objectDataSerializer == null)
						    throw new ArgumentException("No serializer available for type id " + serializationTypeId + " and base type " + typeof(T).FullName);

                        objCopy = obj;
                        objectDataSerializer.PreSerialize(ref objCopy, mode, stream);

                        if (reuseReferences)
                        {
                            // Register object so that later references to it are working.
                            objectReferences[index] = objCopy;
                        }

                        objectDataSerializer.Serialize(ref objCopy, mode, stream);
                        obj = (T)objCopy;
                    }
                    else
                    {
                        if (dataSerializer == null)
                        {
                            dataSerializer = (DataSerializer<T>)context.SerializerSelector.GetSerializer(typeof(T));

                            // If we still have no serializer, throw an exception
                            if (dataSerializer == null)
                                throw new ArgumentException("No serializer available for type " + typeof(T).FullName);
                        }

                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);

                        if (reuseReferences)
                        {
                            // Register object so that later references to it are working.
                            objectReferences[index] = obj;
                        }

                        dataSerializer.Serialize(ref obj, mode, stream);
                    }

                    if (reuseReferences)
                    {
                        // Register object so that later references to it are working.
                        objectReferences[index] = obj;

                        // Call Reference Callback
                        referenceCallback?.Invoke(index, obj);
                    }
                }
            }
        }
    }

    public unsafe class MemberReuseSerializerObject<T> : MemberSerializer<T>
    {
        public MemberReuseSerializerObject(DataSerializer<T> dataSerializer) : base(dataSerializer)
        {
        }

        public override void Serialize(ref T obj, ArchiveMode mode, SerializationStream stream)
        {
            var context = stream.Context;

            if (isValueType)
            {

                // Structure, no need to check for inheritance or null values.
                dataSerializer.Serialize(ref obj, mode, stream);

                return;
            }


            // Serialize either with dataSerializer if obj is really of type T, otherwise look for appropriate serializer.
            SerializeClassFlags flags;
            bool reuseReferences = context.SerializerSelector.ReuseReferences;
            int index;
            bool externalIdentifiableAsGuid = context.SerializerSelector.ExternalIdentifiableAsGuid;
            bool hasTypeInfo;
            object objCopy;
            DataSerializer objectDataSerializer;
            Type type;

            if (mode == ArchiveMode.Serialize)
            {
                if (ReferenceEquals(obj, null))
                {
                    // Null contentRef
                    stream.Write((byte)SerializeClassFlags.IsNull);
                }
                else
                {
                    flags = SerializeClassFlags.None;

                    if (externalIdentifiableAsGuid)
                    {
                        var identifiable = obj as IIdentifiable;
                        var externalIdentifiables = context.Get(MemberSerializer.ExternalIdentifiables);
                        if (identifiable != null && externalIdentifiables?.ContainsKey(identifiable.Id) == true)
                        {
                            flags |= SerializeClassFlags.IsExternalIdentifiable;
                            stream.Write((byte)flags);
                            stream.Write(identifiable.Id);
                            return;
                        }
                    }

                    index = -1;
                    if (reuseReferences)
                    {
                        var objectReferences = context.Get(MemberSerializer.ObjectSerializeReferences);
                        if (objectReferences.TryGetValue(obj, out index))
                        {
                            // Already serialized, just write its contentRef index
                            flags |= SerializeClassFlags.IsReference;
                            stream.Write((byte)flags);
                            stream.Write(index);
                            return;
                        }

                        // First time it is serialized, add it to objectReferences.
                        objectReferences.Add(obj, index = objectReferences.Count);
                    }

                    // If real type is not expected type, we need to store type info as well.
                    var expectedType = typeof(T);
                    type = isSealed ? expectedType : obj.GetType();
                    hasTypeInfo = type != expectedType;
                    objectDataSerializer = null;
                    if (hasTypeInfo)
                    {
                        // Find matching serializer (always required w/ typeinfo, since type was different than expected)
                        objectDataSerializer = context.SerializerSelector.GetSerializer(type);

                        if (objectDataSerializer == null)
                            throw new ArgumentException("No serializer available for type " + type.FullName);

                        // Update expected type
                        type = objectDataSerializer.SerializationType;

                        // Special case: serializer reports the actual serialized type, and it might actually match the expected type
                        // (i.e. there is a hidden inherited type, such as PropertyInfo/RuntimePropertyInfo).
                        // Let's detect it here.
                        if (type == expectedType)
                        {
                            // Cancel type info
                            hasTypeInfo = false;
                        }
                        else
                        {
                            // Continue as expected with type info
                            flags |= SerializeClassFlags.IsTypeInfo;
                        }
                    }

                    // Serialize flags
                    stream.Write((byte)flags);

                    // Serialize object index (if required)
                    if (reuseReferences)
                        stream.Write(index);

                    if (hasTypeInfo)
                    {
                        // Serialize type info
                        fixed (ObjectId* serializationTypeId = &objectDataSerializer.SerializationTypeId)
                            stream.Serialize((IntPtr)serializationTypeId, ObjectId.HashSize);

                        // Serialize object
                        objCopy = obj;
                        objectDataSerializer.PreSerialize(ref objCopy, mode, stream);
                        objectDataSerializer.Serialize(ref objCopy, mode, stream);
                        obj = (T)objCopy;
                    }
                    else
                    {
                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);
                        dataSerializer.Serialize(ref obj, mode, stream);
                    }
                }
            }
            else
            {

                flags = (SerializeClassFlags)stream.ReadByte();
                var isNull = (flags & SerializeClassFlags.IsNull) == SerializeClassFlags.IsNull;
                var objectReferences = reuseReferences ? context.Get(MemberSerializer.ObjectDeserializeReferences) : null;
                var referenceCallback = reuseReferences ? context.Get(MemberSerializer.ObjectDeserializeCallback) : null;
                var isReference = (flags & SerializeClassFlags.IsReference) == SerializeClassFlags.IsReference;
                var isExternalIdentifiable = (flags & SerializeClassFlags.IsExternalIdentifiable) == SerializeClassFlags.IsExternalIdentifiable;
                index = reuseReferences && !isNull && !isExternalIdentifiable ? stream.ReadInt32() : -1;
                hasTypeInfo = (flags & SerializeClassFlags.IsTypeInfo) == SerializeClassFlags.IsTypeInfo;

                if (isNull)
                {
                    obj = default(T);
                }
                else if (externalIdentifiableAsGuid && isExternalIdentifiable)
                {
                    var externalIdentifiables = context.Get(MemberSerializer.ExternalIdentifiables);
					var identifier = stream.Read<Guid>();
					IIdentifiable identifiable;
					externalIdentifiables.TryGetValue(identifier, out identifiable);
                    obj = (T)identifiable;
                }
                else if (reuseReferences && isReference)
                {
                    obj = (T)objectReferences[index];
                }
                else
                {
                    if (reuseReferences)
                    {
                        if (objectReferences.Count != index)
                            throw new InvalidOperationException("Serialization contentRef indices are out of sync.");
                        objectReferences.Add(null);
                    }
                    if (hasTypeInfo)
                    {
                        ObjectId serializationTypeId;
                        stream.Serialize((IntPtr)Interop.FixedOut(out serializationTypeId), ObjectId.HashSize);

                        objectDataSerializer = context.SerializerSelector.GetSerializer(ref serializationTypeId);
						if (objectDataSerializer == null)
						    throw new ArgumentException("No serializer available for type id " + serializationTypeId + " and base type " + typeof(T).FullName);

                        objCopy = obj;
                        objectDataSerializer.PreSerialize(ref objCopy, mode, stream);

                        if (reuseReferences)
                        {
                            // Register object so that later references to it are working.
                            objectReferences[index] = objCopy;
                        }

                        objectDataSerializer.Serialize(ref objCopy, mode, stream);
                        obj = (T)objCopy;
                    }
                    else
                    {
                        // Serialize object
                        dataSerializer.PreSerialize(ref obj, mode, stream);

                        if (reuseReferences)
                        {
                            // Register object so that later references to it are working.
                            objectReferences[index] = obj;
                        }

                        dataSerializer.Serialize(ref obj, mode, stream);
                    }

                    if (reuseReferences)
                    {
                        // Register object so that later references to it are working.
                        objectReferences[index] = obj;

                        // Call Reference Callback
                        referenceCallback?.Invoke(index, obj);
                    }
                }
            }
        }
    }
}